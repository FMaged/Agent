
using Domain.ValueObjects;
using Domain.Exceptions;
using Domain.Enums;
using Domain.Events;


namespace Domain.Entities
{
    public class Person:BaseEntity<int>
    {
        public override int Id => Person_ID; 
        public int Person_ID { get; private set; }
        public string First_Name { get; private set; }
        public string Last_Name { get; private set; }
        public DateTime Date_Of_Birth { get; private set; }
        public eGender Gender { get; private set; }
        public Email EmailAddress { get; private set; }
        public PhoneNumber Phone_Number { get; private set; }
        public Address address { get; private set; }

        private Person() 
        {
            Person_ID = default!;
            First_Name = default!;
            Last_Name = default!;
            Date_Of_Birth = default!;
            Gender = default!;
            EmailAddress = default!;
            Phone_Number = default!;
            address = default!;

        }
        private Person(string firstName, string lastName, DateTime dateOfBirth, eGender gender, Email email, PhoneNumber phoneNumber, Address personAddress)
        {
            ValidateName(firstName, lastName);
            ValidateBirth(dateOfBirth);
            First_Name = firstName;
            Last_Name = lastName;
            Date_Of_Birth = dateOfBirth;
            Gender = ValidateGender(gender);
            this.EmailAddress = email;
            Phone_Number = phoneNumber;
            address = personAddress;

        }
        private Person(int personID, string firstName, string lastName, DateTime dateOfBirth, eGender gender, Email email, PhoneNumber phoneNumber,
                        Address personAddress)
        {
            ValidateName(firstName, lastName);
            ValidateBirth(dateOfBirth);
            Person_ID = personID;
            First_Name = firstName;
            Last_Name = lastName;
            Date_Of_Birth = dateOfBirth;
            Gender = ValidateGender(gender);
            this.EmailAddress = email;
            Phone_Number = phoneNumber;
            address = personAddress;
        }

        public static Person FromDatabase(int personID, string firstName, string lastName, DateTime dateOfBirth,
                                         eGender gender, Email email, PhoneNumber phoneNumber, Address personAddress)
        {

            return new Person(personID, firstName, lastName, dateOfBirth, gender, email, phoneNumber, personAddress);


        }


        /// <summary>
        /// Creates a new Person entity with the provided details.
        /// </summary>
        /// <param name="firstName">The first name of the person.</param>
        /// <param name="lastName">The last name of the person.</param>
        /// <param name="dateOfBirth">The date of birth of the person.</param>
        /// <param name="gender">The gender of the person.</param>
        /// <param name="email">The email address of the person.</param>
        /// <param name="phoneNumber">The phone number of the person.</param>
        /// <param name="personAddress">The address of the person.</param>
        public static Person CreatePerson(string firstName, string lastName, DateTime dateOfBirth, eGender gender, Email email,
                                          PhoneNumber phoneNumber, Address personAddress)
        {

            return new Person(firstName, lastName, dateOfBirth, gender, email, phoneNumber, personAddress);


        }

        public void Update(Email email)
        {
            Email OldEmail = this.EmailAddress;
            this.EmailAddress = email;

            AddDomainEvent(new EmailUpdatedEvent(OldEmail,this.EmailAddress));
        }
        public void Update(PhoneNumber phoneNumber)
        {

            PhoneNumber oldNumber=this.Phone_Number;
            Phone_Number = phoneNumber;
            AddDomainEvent(new PhoneNumberUpdatedEvent(oldNumber, this.Phone_Number));
        }
        public void Update( Address personAddress)
        {
            address = personAddress;
        }
        public void UpdatePerson( Email email, PhoneNumber phoneNumber, Address personAddress)
        {

            this.EmailAddress = email;
            Phone_Number = phoneNumber;
            address = personAddress;
        }

        private static void ValidateName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw InvalidPersonException.MissingName();
            if (string.IsNullOrWhiteSpace(lastName))
                throw InvalidPersonException.MissingName();

            if (firstName.Length > 50)
                throw InvalidPersonException.InvalidName(firstName);
            if(lastName.Length > 50)
                throw InvalidPersonException.InvalidName(lastName);

        }
        private static void ValidateBirth(DateTime dateOfBirth)
        {   
            if (dateOfBirth > DateTime.Now.AddYears(-18)|| dateOfBirth < DateTime.Now.AddYears(-120))
                throw InvalidPersonException.InvalidDate(dateOfBirth);
       

        }
        private static eGender ValidateGender(eGender gender)
        {
            return Enum.IsDefined(typeof(eGender), gender) ? gender : throw InvalidPersonException.InvalidGender();
        }

    }
}
