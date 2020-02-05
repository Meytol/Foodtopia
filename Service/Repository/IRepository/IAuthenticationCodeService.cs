using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repository.IRepository
{
    public interface IAuthenticationCodeService : IgenericRepository<AuthenticationCode>
    {
        AuthenticationCode Get(int authenticationCodeId);
        AuthenticationCode GetByUserId(int userId);
        AuthenticationCode GetByCode(string code);
        AuthenticationCode Update(VMAuthenticationCode authenticationCode);
        AuthenticationCode ExtendExpireTime(int authenticationCodeId);
        AuthenticationCode Create(int userId);
        string GenerateUniqueCode(int length);
        bool Check(string code, int userId);
    }
}
