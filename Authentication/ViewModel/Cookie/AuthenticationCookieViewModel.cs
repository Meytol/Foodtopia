using System;
using System.Collections.Generic;

namespace Authentication.ViewModel.Cookie
{
    public class AuthenticationCookieViewModel
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool RememberMe { get; set; }
        public DateTime MaxAgeDateTime { get; set; }
    }
}