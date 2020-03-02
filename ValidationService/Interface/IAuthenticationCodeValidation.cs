using DataAccess.Model;
using ValidationService.Structure;

namespace ValidationService.Interface
{
    public interface IAuthenticationCodeValidation : IGenericValidation<AuthenticationCode>
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
