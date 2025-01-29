
using Domain.Enums;
using Domain.ValueObjects;
using Domain.Exceptions;
using Domain.Events;


namespace Domain.Entities
{
    public class Employer:BaseEntity<int>
    {
        public override int Id => Employers_ID;
        public int Employers_ID { get;private set; }
        public eIndustry Industry { get;private set; }
        public int? CompanySize { get;private set; }
        public WebSite? Website { get;private set; }
        public RegistrationNumber Registration_Number { get;private set; }
        public string Company_Name { get;private set; }
        public Person Contact_Person { get;private set; }

        private Employer() 
        {
            Employers_ID = default!;
            Industry = default!;
            CompanySize = default!;
            Website = default!;
            Registration_Number = default!;
            Company_Name = default!;
            Contact_Person = default!;
        }
        private Employer(int employers_ID, eIndustry industry, int? companySize, WebSite? website, RegistrationNumber registration_Number,
                        string company_Name, Person contact_Person)
        {
            ValidateName(company_Name);
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
        private Employer(eIndustry industry, int? companySize, WebSite? website, RegistrationNumber registration_Number, string company_Name,
                        Person contact_Person)
        {
            ValidateName(company_Name);
            ValidateIndustry(industry);
            ValidateSize(companySize);
            Industry = industry;
            CompanySize = companySize;
            Website = website;
            Registration_Number = registration_Number;
            Company_Name = company_Name;
            Contact_Person = contact_Person;
        }
        public static Employer FromDatabase(int employers_ID, eIndustry industry, int? companySize, WebSite? website, RegistrationNumber registration_Number,
                        string company_Name, Person contact_Person)
        {
            return new Employer(employers_ID, industry, companySize, website,registration_Number,company_Name, contact_Person);
        }


        public static Employer CreateEmployer(eIndustry industry, int? companySize, WebSite? website, RegistrationNumber registration_Number, string company_Name,
                        Person contact_Person)
        {
            Employer NewEmployer =new Employer(industry, companySize, website,registration_Number, company_Name, contact_Person);
            NewEmployer.AddDomainEvent(new EmployerCreatedEvent(NewEmployer));
            return NewEmployer;
        }
        public void UpdateEmployer(eIndustry industry, int? companySize, WebSite? website,
                        string company_Name, Person contact_Person)
        {
            Employer oldEmployer = this;
            ValidateName(company_Name);
            ValidateSize(companySize);
            ValidateIndustry(industry);
            this.Industry = industry;
            this.CompanySize = companySize;
            this.Website = website;
            this.Company_Name = company_Name;
            this.Contact_Person = contact_Person;



            AddDomainEvent(new EmployerUpdatedEvent(oldEmployer, this));
        }




        private void ValidateName(string name)
        {
            ///Validate the Name
            if (string.IsNullOrEmpty(name))
                throw InvalidEmployerException.MissingCompanyName();
        
        
        
        }
        private void ValidateSize(int? companySize)
        {
            if (companySize < 1)
                throw InvalidEmployerException.InvalidCompanySize(companySize);
        }
        
        private void ValidateID(int id)
        {
            if (id < 1)
                throw DomainException.Invalid_ID(id);
        }
        private void ValidateIndustry(eIndustry industry)
        {
            
            if (!Enum.IsDefined(typeof(eIndustry), industry))
                throw InvalidEmployerException.InvalidIndustry();
        }


    }
}
