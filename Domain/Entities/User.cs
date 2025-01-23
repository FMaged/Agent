using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public eUserRole Role { get; set; } // Updated to use the enum
        public int PersonID { get; set; } // Foreign Key linking to Person

        public User() 
        {
            UserID = 0;
            Username = "Guest";
            PasswordHash = "Guest";
            Role = eUserRole.Guest;
            PersonID = 0;

        }

        public User(string username, string passwordHash, eUserRole role, int personId)
        {
            _ValidateAddressData();
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
            PersonID = personId;

        }

        public User(int userId, string username, string passwordHash, eUserRole role, int personId)
        {
            _ValidateAddressData();
            UserID = userId;
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
            PersonID = personId;

        }
        private void _ValidateAddressData()
        {
            // Validate the Address and then Trow InvalidAddressException
            if (UserID < 1||PersonID<1)
            {
                throw new InvalidUserException("The IDs cant be 0");
            }
            if (Username == null)
            {
                throw new InvalidUserException("UserName cant be Null");
            }




        }

    }
}
