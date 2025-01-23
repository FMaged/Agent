

using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Job_Offer
    {


        public int Job_ID { get; }
        public int Employers_ID { get; }
        public string Job_Name { get; set; }
        public eJobType Job_Type { get; set; }
        public int reference_number { get;}
        public eIndustry industry { get; set; }
        public eWorkingHours WorkingHours { get; set; }
        public DateTime entry_date { get; set; }
        public DateTime release_date { get;}
        public DateTime change_date { get; set; }  
        public int number_of_applicants { get; set; }
        public SalaryRange? SalaryRange { get; set; }
        public string JobDescription { get; set; }

        public Job_Offer(int job_ID, int employers_ID, string job_Name, eJobType job_Type, int reference_number, eIndustry industry, 
                        eWorkingHours workingHours, DateTime entry_date, DateTime release_date, DateTime change_date, int number_of_applicants, 
                        SalaryRange salaryRange, string jobDescription)


        {
            Job_ID = job_ID;
            Employers_ID = employers_ID;
            Job_Name = job_Name;
            Job_Type = job_Type;
            this.reference_number = reference_number;
            this.industry = industry;
            WorkingHours = workingHours;
            this.entry_date = entry_date;
            this.release_date = release_date;
            this.change_date = change_date;
            this.number_of_applicants = number_of_applicants;
            SalaryRange = salaryRange;
            JobDescription = jobDescription;
        }

        public Job_Offer(int employers_ID, string job_Name, eJobType job_Type, int reference_number, eIndustry industry, 
                        eWorkingHours workingHours, DateTime entry_date, DateTime release_date, DateTime change_date, int number_of_applicants, 
                        SalaryRange salaryRange, string jobDescription)
        {
            Employers_ID = employers_ID;
            Job_Name = job_Name;
            Job_Type = job_Type;
            this.reference_number = reference_number;
            this.industry = industry;
            WorkingHours = workingHours;
            this.entry_date = entry_date;
            this.release_date = release_date;
            this.change_date = change_date;
            this.number_of_applicants = number_of_applicants;
            SalaryRange = salaryRange;
            JobDescription = jobDescription;
        }
    }
}
