using FantasyFootball.Entity.Models;

namespace FantasyFootball.Service.AdvancedServices.UserServiceA.Authenticator.Models
{
    public class AuthenticationResultModel
    {
        public User User {get; set;}
        public string TokenString {get; set;}
    }
}
