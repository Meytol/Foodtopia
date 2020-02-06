﻿using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;
using System;
using System.Linq;

namespace Service.Repository
{
    public class AuthenticationCodeService : GenericRepository<AuthenticationCode>, IAuthenticationCodeService
    {
        private readonly Random _random = new Random();

        private readonly ISettingService _settingService;

        public AuthenticationCodeService(DatabaseContext context, ISettingService settingService)
            :base(context)
        {
            _settingService = settingService;

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

            var code = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());

            while (isDuplicate)
            {
                counter++;
                if (GetByCode(code) == null)
                {
                    isDuplicate = false;
                    continue;
                }

                if (counter >= 3 && length <= 10)
                {
                    length++;
                    counter = 0;
                }

                code = GenerateUniqueCode();
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

        public AuthenticationCode GetByUserId(int userId)
        {
            throw new System.NotImplementedException();

        }
    }
}
