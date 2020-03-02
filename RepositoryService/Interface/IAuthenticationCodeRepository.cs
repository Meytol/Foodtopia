using DataAccess.Model;
using RepositoryService.Structure;

namespace RepositoryService.Interface
{
    public interface IAuthenticationCodeRepository : IGenericRepository<AuthenticationCode>
    {
        AuthenticationCode Get(int authenticationCodeId);
        AuthenticationCode GetByUserId(int userId);
        AuthenticationCode GetByCode(string code);
        bool IsUniqueCode(string code);
        AuthenticationCode Update(AuthenticationCode authenticationCode);
        AuthenticationCode ExtendExpireTime(int authenticationCodeId);
        AuthenticationCode Create(int userId);
        string GenerateUniqueCode(int length);
        bool Check(string code, int userId);
    }
}
