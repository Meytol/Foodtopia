using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using Authentication.Interface;
using Authentication.ViewModel.Cookie;
using Authentication.ViewModel.Session;
using Common.Model;
using DataAccess.Common.Enum;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryService.Interface;
using RepositoryService.Models.User;

namespace Authentication.Service
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleActionRepository _roleActionRepository;
        private readonly IApplicationActionRepository _actionRepository;


        public AuthorizeService(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IRoleActionRepository roleActionRepository, IApplicationActionRepository actionRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleActionRepository = roleActionRepository;
            _actionRepository = actionRepository;
        }

        public bool CheckUserPermision(string areaTitle, string controllerTitle, string actionTitle, int userId)
        {
            ApplicationAction actionResult;

            if (string.IsNullOrWhiteSpace(areaTitle))
            {
                actionResult = _actionRepository.GetAllIncluding(controller =>
                        string.Equals(controller.Title, controllerTitle,
                            StringComparison.CurrentCultureIgnoreCase) &&
                        controller.ActionLevel == (int) ActionLevel.Controller)
                    .Data.Include(controller =>
                        controller.Childs)
                    .SingleOrDefault(action => string.Equals(action.Title, actionTitle,
                                          StringComparison.CurrentCultureIgnoreCase) &&
                                      action.ActionLevel == (int) ActionLevel.Action);

            }
            else
            {
                actionResult = _actionRepository.GetAllIncluding(area =>
                        string.Equals(area.Title, areaTitle,
                            StringComparison.CurrentCultureIgnoreCase) &&
                        area.ActionLevel == (int) ActionLevel.Area)
                    .Data.Include(area =>
                        area.Childs)
                    .Where(controller => string.Equals(controller.Title, controllerTitle,
                                             StringComparison.CurrentCultureIgnoreCase) &&
                                         controller.ActionLevel == (int) ActionLevel.Controller)
                    .Include(controller =>
                        controller.Childs)
                    .SingleOrDefault(action => string.Equals(action.Title, actionTitle,
                                                  StringComparison.CurrentCultureIgnoreCase) &&
                                              action.ActionLevel == (int) ActionLevel.Action);
            }

            var actionRoles = _roleActionRepository.FindBy(ur => ur.ActionId == actionResult.Id);

            var userRoles = new List<DbResult<UserRole>>();

            foreach (var actionRole in actionRoles.Data)
            {
                var userRole = _userRoleRepository.Find(ur => ur.RoleId == actionRole.RoleId);

                userRoles.Add(userRole);
            }

            return userRoles.Any(e => e.Data.UserId == userId);
        }

        public bool CheckUserCookie(AuthenticationCookieViewModel authenticationCookie)
        {
            return authenticationCookie != null;
        }

        public bool CheckUserSession(AuthenticationSessionViewModel authenticationSession)
        {
            return authenticationSession != null;
        }

        public SignInViewModel GetUser(string phoneNumber, string password)
        {

            var userVm = new SignInViewModel()
            {
                PhoneNumber = phoneNumber,
                Password = password
            };


            var dbResult = _userRepository.SignIn(userVm).Result;

            if (!dbResult.Success || dbResult.Data == null)
                return null;

            var user = dbResult.Data;

            if (user.IsLockout && user.LockoutEnd.HasValue)
            {
                if (user.LockoutEnd.Value > DateTime.Now)
                {
                    return null;
                }
                else
                {
                    _userRepository.DisableLckout(user.Id).RunSynchronously();
                }
            }
            else if (user.IsLockout && !user.LockoutEnd.HasValue)
            {
                return null;
            }

            return dbResult.Data;
        }
    }
}