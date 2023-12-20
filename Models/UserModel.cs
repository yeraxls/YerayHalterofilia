using db.Models;

namespace YerayHalterofilia.Models
{
    public class UserModel
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string EmailAddress { get; set; }
        public required string LastName { get; set;}
        public required string FirstName { get; set; }

        public static explicit operator User(UserModel user)
        {
            return new User
            {
                UserName = user.UserName,
                Password = user.Password,
                EmailAddress = user.EmailAddress,
                LastName = user.LastName,
                FirstName = user.FirstName
            };
        }
    }
}
