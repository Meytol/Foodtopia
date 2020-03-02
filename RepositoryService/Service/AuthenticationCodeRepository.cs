using System;
using System.Linq;
using Common.Model.Enum;
using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class AuthenticationCodeRepository : GenericRepository<AuthenticationCode>, IAuthenticationCodeRepository
    {
        private readonly Random _random = new Random();

        private readonly ISettingRepository _settingRepository;
        public AuthenticationCodeRepository(DatabaseContext context,IAuthenticationCodeValidation validation, ISettingRepository settingRepository)
            :base(context, validation)
        {
            _settingRepository = settingRepository;
        }


        public AuthenticationCode Create(int userId)
        {
            throw new System.NotImplementedException();

        }

        public AuthenticationCode ExtendExpireTime(int authenticationCodeId)
        {
            throw new System.NotImplementedException();

        }

        public string GenerateUniqueCode(int length = 5)
        {
            //const string chars = "0123456789";
            const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNM";
            //const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            var isDuplicate = true;
            var counter = 0;

            var code = string.Empty;
            
            while (isDuplicate)
            {
                code = new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[_random.Next(s.Length)]).ToArray());

                if (IsUniqueCode(code))
                {
                    isDuplicate = false;
                }
                else
                {
                    if (counter >= 3 && length <= 10)
                    {
                        length++;
                        counter = 0;
                    }
                    counter++;
                }
            }

            return code;
        }

        public AuthenticationCode Get(int authenticationCodeId)
        {
            throw new System.NotImplementedException();

        }

        public AuthenticationCode Update(AuthenticationCode authenticationCode)
        {
            throw new System.NotImplementedException();

        }

        public bool Check(string code, int userId)
        {
            throw new System.NotImplementedException();

        }

        public AuthenticationCode GetByCode(string code)
        {
            throw new System.NotImplementedException();
        }

        public bool IsUniqueCode(string code)
        {
            var dbresult = Find(c => c.Code == code && c.IsUse == false);

            if (!dbresult.Success)
            {
                return false;
            }

            return dbresult.Data == null || dbresult.Data.Id == 0;
        }

        public AuthenticationCode GetByUserId(int userId)
        {
            throw new System.NotImplementedException();

        }
    }
}
