using System.ComponentModel.DataAnnotations;

namespace RepositoryService.Models.User
{
    public class SignInViewModel
    {
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public int Id { get; set; }
        public string Fullname { get; set; }
    }
}