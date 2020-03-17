using System.ComponentModel.DataAnnotations;

namespace RepositoryService.Models.User
{
    public class SignUpViewModel
    {
        public int? Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public bool IsMale { get; set; }
    }
}