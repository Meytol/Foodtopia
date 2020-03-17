using System;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Authentication.ViewModel.Session;
using Common.Cryptography.Interface;
using Foodtopia.MiniServices.Intereface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Foodtopia.MiniServices.Service
{
    public class AuthenticationSessionService : IAuthenticationSessionService
    {
        private readonly IConfiguration _configuration;
        private readonly ICryptographyService _cryptographyService;
        private readonly string _sessionName;
        private readonly string _encryptionKey;
        private readonly string _oldEncryptionKey;

        public AuthenticationSessionService(IConfiguration configuration, ICryptographyService cryptographyService)
        {
            _configuration = configuration;
            _cryptographyService = cryptographyService;

            _encryptionKey = _configuration.GetValue<string>("AppSetting:AuthSessionEncryptionKey");
            _oldEncryptionKey = _configuration.GetValue<string>("AppSetting:OldAuthSessionEncryptionKey");
            _sessionName = _configuration.GetValue<string>("AppSetting:AuthSessionName");
        }

        public AuthenticationSessionViewModel Get(HttpContext context)
        {
            try
            {
                if (!context.Session.TryGetValue(_sessionName, out var sessionBytes))
                {
                    return null;
                }

                var encryptedAuthSession = Encoding.UTF8.GetString(sessionBytes);

                var session =
                    _cryptographyService.Decrypt<AuthenticationSessionViewModel>(encryptedAuthSession, _encryptionKey) ??
                    _cryptographyService.Decrypt<AuthenticationSessionViewModel>(encryptedAuthSession, _oldEncryptionKey);

                return session;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

        }

        public void Set(HttpContext context, AuthenticationSessionViewModel sessionViewModel)
        {
            var cipherSession = _cryptographyService.Encrypt(sessionViewModel, _encryptionKey);
            
            var session = Encoding.UTF8.GetBytes(cipherSession);

            context.Session.Set(_sessionName, session);
        }

        public void Update(HttpContext context, AuthenticationSessionViewModel sessionViewModel)
        {
            Remove(context);

            Set(context, sessionViewModel);
        }

        public void Remove(HttpContext context)
        {
            context.Session.Remove(_encryptionKey);   
        }

    }
}