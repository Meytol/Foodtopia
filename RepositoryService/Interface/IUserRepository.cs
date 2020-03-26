using System.Threading.Tasks;
using Common.Model;
using DataAccess.Model;
using RepositoryService.Models.User;
using RepositoryService.Structure;

namespace RepositoryService.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<ApiResult<SignUpViewModel>> SignUp(SignUpViewModel model);
        Task<ApiResult<SignInViewModel>> SignIn(SignInViewModel model);
        Task DisableLckout(int userId);
    }
}