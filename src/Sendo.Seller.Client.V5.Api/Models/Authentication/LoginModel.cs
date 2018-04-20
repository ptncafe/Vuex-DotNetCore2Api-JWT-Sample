using System.ComponentModel.DataAnnotations;

namespace Sendo.Seller.Client.V5.Api.Models.Authentication
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}