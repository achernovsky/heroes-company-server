using System.ComponentModel.DataAnnotations;

namespace heroes_company_api.Models
{
    public class RegisterTrainerModel
    {
        [Required(ErrorMessage = "User name is required")]
        [MinLength(6, ErrorMessage = "User name should be at least 6 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
