using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Cryptography.Interface;
using Common.Model;
using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Models.User;
using RepositoryService.Structure;
using ValidationService.Interface;
using System.Security.Cryptography;
using System.Text;
using Common.Model.Enum;

namespace RepositoryService.Service
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ICryptographyService _cryptographyService;

        public UserRepository(DatabaseContext context, IUserValidation validation, ICryptographyService cryptographyService)
        :base(context, validation)
        {
            _cryptographyService = cryptographyService;
        }

        public async Task<ApiResult<SignInViewModel>> SignIn(SignInViewModel model)
        {
            User user;
            var result = new ApiResult<SignInViewModel>();

            if (!string.IsNullOrWhiteSpace(model.PhoneNumber.Trim()))
            {
                var findResult = await FindAsync(u => u.PhoneNumber == model.PhoneNumber.Trim());

                if (!findResult.Success || findResult.Data.Id == 0)
                {
                    result.Success = false;
                    result.Data = null;
                    result.Exception = findResult.Exception;
                    result.Info = findResult.Info;
                    result.Message = "کاربری با این مشخصات یافت نشد";
                    result.MessageType = findResult.MessageType;

                    return result;
                }

                user = findResult.Data;
            }
            else if (!string.IsNullOrWhiteSpace(model.Email))
            {
                var findResult = await FindAsync(u => string.Equals(u.Email, model.Email, StringComparison.CurrentCultureIgnoreCase));

                if (!findResult.Success || findResult.Data.Id == 0)
                {
                    result.Success = false;
                    result.Data = null;
                    result.Exception = findResult.Exception;
                    result.Info = findResult.Info;
                    result.Message = "کاربری با این مشخصات یافت نشد";
                    result.MessageType = findResult.MessageType;

                    return result;
                }

                user = findResult.Data;
            }
            else
            {
                result.Success = false;
                result.Data = null;
                result.Exception = new ArgumentNullException(nameof(model.PhoneNumber));
                result.Message = "فیلد شماره تلفن همراه نمیتواند خالی باشد";
                result.MessageType = MessageType.Error;

                return result;
            }

            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            var encryptedPass = string.Concat(hash.Select(b => b.ToString("x2")));

            if (!string.Equals(user.Password, encryptedPass, StringComparison.CurrentCultureIgnoreCase))
            {
                result.Success = true;
                result.Data = null;
                result.Message = "فیلد شماره تلفن همراه نمیتواند خالی باشد";
                result.MessageType = MessageType.Error;

                return result;
            }

            model.Fullname = user.Fullname;
            model.Id = user.Id;

            result.Success = true;
            result.Data = model;
            result.Message = "کاربر مورد نظر پیدا شد";
            result.MessageType = MessageType.Success;

            return result;
        }

        public async Task<ApiResult<SignUpViewModel>> SignUp(SignUpViewModel model)
        {
            var result = new ApiResult<SignUpViewModel>();

            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            var encryptedPass = string.Concat(hash.Select(b => b.ToString("x2")));
            
            var user = new User
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email.Trim(),
                PhoneNumber = model.PhoneNumber.Trim(),
                IsMale = model.IsMale,
                Password = encryptedPass,
                IsLockout = false,
                EmailConfirmed = false,
                PhonenumberConfirmed = false,
                AccessFailedCount = 0,
                IsActive = true
            };

            var insertResult = await AddAsync(user, null);

            if (!insertResult.Success)
            {
                result.Success = false;
                result.Data = null;
                result.Exception = insertResult.Exception;
                result.Message = insertResult.Message;
                result.Info = insertResult.Info;
                result.MessageType = insertResult.MessageType;

                return result;
            }

            //Send Sms or E-mail verification message

            model.Id = insertResult.Data.Id;

            result.Success = true;
            result.Data = model;
            result.Exception = insertResult.Exception;
            result.Message = insertResult.Message;
            result.Info = insertResult.Info;
            result.MessageType = insertResult.MessageType;

            return result;
        }
    }
}