using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Model;
using DataAccess.Repository;

namespace Service.Repository.IRepository
{
    public interface IAuthenticationCodeService : IGenericRepository<AuthenticationCode>
    {
        AuthenticationCode Get(int authenticationCodeId);
        AuthenticationCode GetByUserId(int userId);
        AuthenticationCode GetByCode(string code);
        AuthenticationCode Update(AuthenticationCode authenticationCode);
        AuthenticationCode ExtendExpireTime(int authenticationCodeId);
        AuthenticationCode Create(int userId);
        string GenerateUniqueCode(int length);
        bool Check(string code, int userId);
    }
}
