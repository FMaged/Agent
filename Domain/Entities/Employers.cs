
using Domain.Enums;
using Domain.ValueObjects;
using Domain.Exceptions;


namespace Domain.Entities
{
    public class Employers:BaseEntity<int>
    {
        public override int Id => Employers_ID;
        public int Employers_ID { get;private set; }
        public eIndustry Industry { get;private set; }
        public int? CompanySize { get;private set; }
        public WebSite? Website { get;private set; }
        public RegistrationNumber Registration_Number { get;private set; }
        public string Company_Name { get;private set; }
        public Person Contact_Person { get;private set; }

        private Employers() 
        {
            Employers_ID = default!;
            Industry = default!;
            CompanySize = default!;
            Website = default!;
            Registration_Number = default!;
            Company_Name = default!;
            Contact_Person = default!;
        }
        private Employers(int employers_ID, eIndustry industry, int? companySize, WebSite? website, RegistrationNumber registration_Number,
                        string company_Name, Person contact_Person)
        {
            ValidateIndustry(industry);
            ValidateID(employers_ID);
            ValidateSize(companySize);
            Employers_ID = employers_ID;
            Industry = industry;
            CompanySize = companySize;
            Website = website;
            Registration_Number = registration_Number;
            Company_Name = company_Name;
            Contact_Person = contact_Person;
        }
        private Employers(eIndustry industry, int? companySize, WebSite? website, RegistrationNumber registration_Number, string company_Name,
                        Person contact_Person)
        {
            ValidateIndustry(industry);
            ValidateSize(companySize);
            Industry = industry;
            CompanySize = companySize;
            Website = website;
            Registration_Number = registration_Number;
            Company_Name = company_Name;
            Contact_Person = contact_Person;
        }
        public static Employers FromDatabase(int employers_ID, eIndustry industry, int? companySize, WebSite? website, RegistrationNumber registration_Number,
                        string company_Name, Person contact_Person)
        {
            return new Employers(employers_ID, industry, companySize, website,registration_Number,company_Name, contact_Person);
        }


        public static Employers CreateEmployer(eIndustry industry, int? companySize, WebSite? website, RegistrationNumber registration_Number, string company_Name,
                        Person contact_Person)
        {
            return new Employers(industry, companySize, website,registration_Number, company_Name, contact_Person);
        }
        public void UpdateEmployer(eIndustry industry, int? companySize, WebSite? website,
                        string company_Name, Person contact_Person)
        {
            ValidateIndustry(industry);
            this.Industry = industry;
            this.CompanySize = companySize;
            this.Website = website;
            this.Company_Name = company_Name;
            this.Contact_Person = contact_Person;

        }





        private void ValidateSize(int? companySize)
        {
            if (companySize < 1)
                throw new InvalidEmployerException("Invalid Size");
        }
        
        private void ValidateID(int id)
        {
            if (id < 1)
                throw new InvalidEmployerException("Invalid Id");
        }
        private void ValidateIndustry(eIndustry industry)
        {
            if (!Enum.IsDefined(typeof(eIndustry), industry))
                throw new InvalidEmployerException("Invalid industry");
        }


    }
}
