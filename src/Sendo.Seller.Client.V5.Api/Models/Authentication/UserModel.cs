using System;

namespace Sendo.Seller.Client.V5.Api.Models.Authentication
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }
}