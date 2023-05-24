using System.ComponentModel.DataAnnotations;

namespace KargomentoUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Username { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string TcNo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
