using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Person
    {
        public int Person_ID { get;}
        public string First_Name { get;}
        public string Last_Name { get;}
        public DateTime Date_Of_Birth { get;}
        public eGender Gender { get;}
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public int address { get; set; }


        public Person(string firstName, string lastName, DateTime dateOfBirth,eGender gender, string email, string phoneNumber,int personAddress)
        {

            First_Name = firstName;
            Last_Name = lastName;
            Date_Of_Birth = dateOfBirth;
            Gender = gender;
            Email = email;
            Phone_Number = phoneNumber;
            address = personAddress;

        }
        public Person(int personID, string firstName, string lastName, DateTime dateOfBirth, eGender gender, string email, string phoneNumber, 
                        int personAddress)
        {
            Person_ID = personID;
            First_Name = firstName;
            Last_Name = lastName;
            Date_Of_Birth = dateOfBirth;
            Gender = gender;
            Email = email;
            Phone_Number = phoneNumber;
            address = personAddress;
        }





    }   
}
