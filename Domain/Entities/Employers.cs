
using Domain.Enums;

namespace Domain.Entities
{
    public class Employers
    {
        public int Employers_ID { get; set; }
        public eIndustry Industry { get; set; }
        public int? CompanySize { get; set; }
        public string? Website { get; set; }
        public string Registration_Number { get; set; }
        public string Company_Name { get; set; }
        public int Contact_Person_ID { get; set; }

        public Employers(int employers_ID, eIndustry industry, int? companySize, string? website, string registration_Number, 
                        string company_Name, int contact_Person_ID)
        {
            Employers_ID = employers_ID;
            Industry = industry;
            CompanySize = companySize;
            Website = website;
            Registration_Number = registration_Number;
            Company_Name = company_Name;
            Contact_Person_ID = contact_Person_ID;
        }
        public Employers(eIndustry industry, int? companySize, string? website, string registration_Number, string company_Name, 
                        int contact_Person_ID)
        {
            Industry = industry;
            CompanySize = companySize;
            Website = website;
            Registration_Number = registration_Number;
            Company_Name = company_Name;
            Contact_Person_ID = contact_Person_ID;
        }

    }
}
