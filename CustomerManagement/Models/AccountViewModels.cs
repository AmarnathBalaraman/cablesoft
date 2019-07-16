using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Models
{

    public class LoginModel
    {
        public string UserID { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class LoginResultModel
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Position { get; set; }
        public byte[] Image { get; set; }
        public string RoleId { get; set; }
    }

    public class GenderModel
    {
        public string GenderID { get; set; }
        public string Description { get; set; }
    }
}
