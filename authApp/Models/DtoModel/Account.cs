using System.ComponentModel.DataAnnotations;

namespace authApp.Models.DtoModel
{
    public class Account
    {
        [Required(ErrorMessage ="Email id Required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string EmailId { get; set; }

        [Required(ErrorMessage ="Password Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(8)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
