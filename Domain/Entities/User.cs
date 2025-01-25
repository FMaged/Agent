using Domain.ValueObjects;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;

namespace Domain.user.Aggregate
{
    public class User:BaseEntity<int>
    {
        public override int Id => UserID;
        public int UserID { get; private set; }
        public UserName userName { get; private set; }
        public Password PasswordHash { get; private set; }
        public eUserRole Role { get; private set; }
        public Person? Person { get; private set; }

        // Private constructor for ORM
        private User()
        {
            UserID = default!;
            userName = default!;
            PasswordHash = default!;
            Role = default!;
            Person = default!;

        }

        // Constructor for Guest users
        private User(eUserRole role)
        {
            if (role != eUserRole.Guest)
                throw new InvalidUserException("This constructor is for Guest users only");

            // maybe make a Table to store the Guests!
            userName = default!;
            PasswordHash = default!;

            Role = role;

        }

        private User(int User_ID, UserName username, Password passwordHash, eUserRole role, Person person)
        {
            UserID = User_ID;
            userName = username ?? throw new ArgumentNullException(nameof(username));
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            Role = ValidateRole(role);
        }

        // Constructor for registered users
        private User(UserName username, Password passwordHash, eUserRole role, Person person)
        {
            userName = username ?? throw new ArgumentNullException(nameof(username));
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            Role = ValidateRole(role);

        }
        public static User FromDatabase(int User_ID, UserName username, Password passwordHash, eUserRole role, Person person)
        {
            return new User(User_ID, username, passwordHash, role, person);
        }

        // Factory method for Guest users
        public static User CreateGuest()
        {
            return new User(eUserRole.Guest);
        }

        // Factory method for registered users
        public static User CreateRegistered(
            UserName username,
            Password passwordHash,
            Person person)
        {
            return new User(username, passwordHash, eUserRole.User, person);
        }

        // Domain behavior: Upgrade Guest to registered user
        public void Register(UserName username, Password passwordHash, Person person)
        {
            if (Role != eUserRole.Guest)
                throw new InvalidUserException("Only Guest users can register");

            userName = username ?? throw new ArgumentNullException(nameof(username));
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));

            Role = eUserRole.User; // Default role after registration
        }

        // Domain behavior: Change username (for registered users)
        public void ChangeUsername(UserName newUsername)
        {
            if (Role == eUserRole.Guest)
                throw new InvalidUserException("Guests cannot have a username");

            userName = newUsername ?? throw new ArgumentNullException(nameof(newUsername));
        }

        // Domain behavior: Change password (for registered users)
        public void ChangePassword(Password newPasswordHash)
        {
            if (Role == eUserRole.Guest)
                throw new InvalidUserException("Guests cannot have a password");

            PasswordHash = newPasswordHash ?? throw new ArgumentNullException(nameof(newPasswordHash));
        }

        // Validation logic
        private eUserRole ValidateRole(eUserRole role)
        {
            return Enum.IsDefined(typeof(eUserRole), role) ? role : throw new InvalidUserException("Invalid user role");
        }


    }
}