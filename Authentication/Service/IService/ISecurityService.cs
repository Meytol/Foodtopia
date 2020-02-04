using System.Threading.Tasks;

namespace Authentication.Service.IService
{
    public interface ISecurityService
    {
        Task<string> Encrypt(string plainText, string key);

        Task<T> Decrypt<T>(string cipherText, string key);
    }
}