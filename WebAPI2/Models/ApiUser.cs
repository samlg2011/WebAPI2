using static WebAPI2.Common.EnumAuthenticationType;

namespace WebAPI2.Models
{
    public class ApiUser
    {
        public int UserId { get; set; }
        public string LogonName { get; set; }
        public string LogonPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public AuthenticationType AuthenticationType { get; set; }
        public string AuthenticationToken { get; set; }
        public static bool ValidateToken(string token)
        {
            // Doing validate here, eg, check DB exist etc.
            return true;
        }
        public static ApiUser GetUserDetail(string token)
        {
            // Get User detail using access token, eg, get from DB etc.
            ApiUser returnUser = new ApiUser()
            {
                UserId = 1,
                LogonName = "Test User",
                LogonPassword = "123",
                FirstName = "Test",
                LastName = "User",
                Company = "ABC",
                AuthenticationType = AuthenticationType.Tester,
                AuthenticationToken = token
            };
            return returnUser;
        }
    }
}