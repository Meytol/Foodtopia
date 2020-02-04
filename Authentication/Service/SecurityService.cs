using Authentication.Service.IService;
using System.Threading.Tasks;

namespace Authentication.Service
{
    public class SecurityService : ISecurityService
    {
        public async Task<string> Encrypt(string plainText, string key)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> Decrypt<T>(string cipherText, string key)
        {
            throw new System.NotImplementedException();
        }
    }
}