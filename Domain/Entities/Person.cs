using Domain.Enums;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Person
    {
        public int Person_ID { get; private set; }
        public string First_Name { get; private set; }
        public string Last_Name { get; private set; }
        public DateTime Date_Of_Birth { get; private set; }
        public eGender Gender { get; private set; }
        public Email email { get; private set; }
        public PhoneNumber Phone_Number { get; private set; }
        public Address address { get; private set; } 

        private Person() { }
        private Person(string firstName, string lastName, DateTime dateOfBirth,eGender gender, Email email, PhoneNumber phoneNumber,Address personAddress)
        {
            ValidateName(firstName, lastName);
            ValidateBirth(dateOfBirth);
            this.First_Name = firstName;
            this.Last_Name = lastName;
            this.Date_Of_Birth = dateOfBirth;
            this.Gender = ValidateGender(gender);
            this.email = email;
            this.Phone_Number = phoneNumber;
            this.address = personAddress;

        }
        private Person(int personID, string firstName, string lastName, DateTime dateOfBirth, eGender gender, Email email, PhoneNumber phoneNumber, 
                        Address personAddress)
        {
            ValidateName(firstName, lastName);
            ValidateBirth(dateOfBirth); 
            this.Person_ID = personID;
            this.First_Name = firstName;
            this.Last_Name = lastName;
            this.Date_Of_Birth =dateOfBirth;
            this.Gender = ValidateGender(gender);
            this.email = email;
            this.Phone_Number = phoneNumber;
            this.address = personAddress;
        }

        public static Person FromDatabase(int personID, string firstName, string lastName, DateTime dateOfBirth,
                                         eGender gender, Email email, PhoneNumber phoneNumber,Address personAddress)
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

        
        public void UpdatePerson(string firstName,string lastName, Email email, PhoneNumber phoneNumber, Address personAddress)
        {
            ValidateName(firstName, lastName);
            First_Name = firstName;
            Last_Name = lastName;
            this.email = email;
            this.Phone_Number=phoneNumber;
            this.address = personAddress;
        }

        private static void ValidateName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > 50)
                throw new InvalidPersonException("First name must be 1-50 characters");
            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > 50)
                throw new InvalidPersonException("Last name must be 1-50 characters");

        }
        private static void ValidateBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth > DateTime.Now.AddYears(-18))
                throw new InvalidPersonException("Person must be at least 18 years old");
            if (dateOfBirth < DateTime.Now.AddYears(-120))
                throw new InvalidPersonException("Invalid date of birth");
            
        }
        private static eGender ValidateGender(eGender gender)
        {
            return Enum.IsDefined(typeof(eGender), gender) ? gender : throw new InvalidPersonException("Invalid Gender");
        }

    }   
}
