using Domain.Enums;
using Domain.Exceptions;
using Domain.ValueObjects;
using System.Text.RegularExpressions;
namespace Domain.Entities
{
    public class Job_Offer:BaseEntity<int>
    {

        public override int Id => Job_ID;
        public int Job_ID { get;private set; }
        public int Employers_ID { get; private set; }
        public string Job_Name { get;private set; }
        public eJobType Job_Type { get;private set; }
        public int Reference_number { get; private set; }
        public eIndustry Industry { get;private set; }
        public eWorkingHours WorkingHours { get;private set; }
        public DateTime Entry_date { get;private set; }
        public DateTime Release_date { get; private set; }
        public DateTime? Last_change_date { get;private set; }
        public int Number_of_applicants { get;private set; }
        public SalaryRange? SalaryRange { get;private set; }
        public string JobDescription { get;private set; }

        private Job_Offer()
        {
            this.Job_ID = default!;
            this.Employers_ID = default!;
            this.Job_Name = default!;
            this.Job_Type = default!;
            this.Reference_number = default!;
            this.Industry = default!;
            this.WorkingHours = default!;
            this.Entry_date = default!;
            this.Release_date = default!;
            this.Last_change_date = default!;
            this.Number_of_applicants = default!;
            this.SalaryRange = default!;
            this.JobDescription = default!;
        }

        //JOb From DataBase
        private Job_Offer(int job_ID, int employers_ID, string job_Name, eJobType job_Type, int reference_number, eIndustry industry,
                        eWorkingHours workingHours, DateTime entry_date,DateTime release_date,DateTime last_change_date, int number_of_applicants,
                        SalaryRange salaryRange, string jobDescription)


        {
            
            Validate(job_ID, employers_ID, job_Name, job_Type, reference_number, industry, workingHours,
                                entry_date,entry_date, last_change_date,number_of_applicants, salaryRange, jobDescription);
            this.Job_ID = job_ID;
            this.Employers_ID = employers_ID;
            this.Job_Name = job_Name;
            this.Job_Type = job_Type;
            this.Reference_number = reference_number;
            this.Industry = industry;
            this.WorkingHours = workingHours;
            this.Entry_date = entry_date;
            this.Last_change_date = last_change_date;
            this.Release_date = release_date;
            this.Number_of_applicants = number_of_applicants;
            this.SalaryRange = salaryRange;
            this.JobDescription = jobDescription;
        }


        //New Job
        private Job_Offer(int employers_ID, string job_Name, eJobType job_Type, int reference_number, eIndustry industry,
                        eWorkingHours workingHours, DateTime entry_date, int number_of_applicants,
                        SalaryRange salaryRange, string jobDescription)
        {
            Validate(employers_ID, job_Name, job_Type, reference_number, industry, workingHours,
                                entry_date, number_of_applicants, salaryRange, jobDescription);

            this.Employers_ID = employers_ID;
            this.Job_Name = job_Name;
            this.Job_Type = job_Type;
            this.Reference_number = reference_number;
            this.Industry = industry;
            this.WorkingHours = workingHours;
            this.Entry_date = entry_date;
            this.Release_date = DateTime.Now;
            this.Last_change_date = null;
            this.Number_of_applicants = number_of_applicants;
            this.SalaryRange = salaryRange;
            this.JobDescription = jobDescription;
        }
        public static Job_Offer FromDatabase(int job_ID, int employers_ID, string job_Name, eJobType job_Type, int reference_number, eIndustry industry,
                        eWorkingHours workingHours, DateTime entry_date, DateTime release_date, DateTime change_date, int number_of_applicants,
                        SalaryRange salaryRange, string jobDescription)
        {
            return new Job_Offer(job_ID, employers_ID, job_Name, job_Type, reference_number, industry, workingHours,
                                entry_date, release_date, change_date, number_of_applicants, salaryRange, jobDescription);
        }

        public static Job_Offer createJob(int employers_ID, string job_Name, eJobType job_Type, int reference_number, eIndustry industry,
                        eWorkingHours workingHours, DateTime entry_date, DateTime release_date, DateTime change_date, int number_of_applicants,
                        SalaryRange salaryRange, string jobDescription)
        {
            return new Job_Offer(employers_ID, job_Name, job_Type, reference_number, industry, workingHours,
                                entry_date, number_of_applicants, salaryRange, jobDescription);
        }
    
        public void UpdateJob(int employers_ID, string job_Name, eJobType job_Type, int reference_number, eIndustry industry,
                        eWorkingHours workingHours, DateTime entry_date, DateTime release_date, DateTime change_date, int number_of_applicants,
                        SalaryRange salaryRange, string jobDescription)
        {
            Validate(employers_ID, job_Name, job_Type, reference_number, industry, workingHours,
                                entry_date, number_of_applicants, salaryRange, jobDescription);
            this.Employers_ID = employers_ID;
            this.Job_Name = job_Name;
            this.Job_Type = job_Type;
            this.Reference_number = reference_number;
            this.Industry = industry;
            this.WorkingHours = workingHours;
            this.Entry_date = entry_date;
            this.Release_date = release_date;
            this.Last_change_date = DateTime.Now;
            this.Number_of_applicants = number_of_applicants;
            this.SalaryRange = salaryRange;
            this.JobDescription = jobDescription;
        }

        //New Job

        private void Validate( int employers_ID, string job_Name, eJobType job_Type, int reference_number, eIndustry industry,
                        eWorkingHours workingHours, DateTime entry_date, int number_of_applicants,
                        SalaryRange salaryRange, string jobDescription)
        {
            ValidateID(1, employers_ID);
            ValidateName(Job_Name);
            ValidateEnums(Job_Type, industry, workingHours);
            ValidateDate(entry_date);
            Validate_Number_of_applicants(number_of_applicants);
        }
        //JOb From DataBase

        private void Validate(int job_ID, int employers_ID, string job_Name, eJobType job_Type, int reference_number, eIndustry industry,
                        eWorkingHours workingHours, DateTime entry_date,DateTime release_date,DateTime last_change_date, int number_of_applicants,
                        SalaryRange salaryRange, string jobDescription)
        {
            ValidateID(job_ID,employers_ID);
            ValidateName(Job_Name);
            ValidateEnums(Job_Type,industry,workingHours);
            ValidateDate(entry_date,release_date,last_change_date);
            Validate_Number_of_applicants(number_of_applicants);
        }
        private void ValidateEnums(eJobType job_Type, eIndustry industry, eWorkingHours workingHours)
        {
            if (Enum.IsDefined(typeof(eJobType), job_Type))
                throw new InvalidJobException("Invalid eJobType");
            if(Enum.IsDefined(typeof(eIndustry), industry))
                throw new InvalidJobException("Invalid eIndustry");
            if (Enum.IsDefined(typeof(eWorkingHours), workingHours))
                throw new InvalidJobException("Invalid eWorkingHours");
        }
        private void Validate_Number_of_applicants(int number_of_applicants)
        {
            if (number_of_applicants < 0)
                throw new InvalidJobException("number of Applicants cant be negative");
        }

        //JOb From DataBase
        private void ValidateDate(DateTime entry_date,DateTime release_date,DateTime last_change_date)
        {

            if (entry_date < DateTime.Now)
                throw new InvalidJobException("Invalid Entry Date, Must be in the future");
            if(release_date>DateTime.Now)
                throw new InvalidJobException("Invalid release Date, Must be in the Bast");
            if (last_change_date > DateTime.Now)
                throw new InvalidJobException("Invalid Last_Change Date, Must be in the bast");

        }

        //New Job
        private void ValidateDate(DateTime entry_date)
        {
            if (entry_date > DateTime.Now)
                throw new InvalidJobException("Invalid Entry Date Must be in the future");
            if (Last_change_date is not null)
                throw new InvalidJobException("Last change date must be null when creating new Job_Offer");

        }
        private void ValidateName(string job_Name)
        {
            if (string.IsNullOrEmpty(job_Name))
                throw new InvalidJobException("Name cant be empty OR null");
            var trimmed = job_Name.Trim();

            if (trimmed.Length < 5 || trimmed.Length > 20)
                throw new InvalidUserException("Username must be 5-20 characters");
            var pattern = @"^[A-Za-z][A-Za-z0-9._&-]{4,19}$";
            if (!Regex.IsMatch(trimmed, pattern))
                throw new InvalidUserException("Invalid username format");


        }
        private void ValidateID(int job_ID, int employers_ID)
        {
            if (employers_ID < 1|| job_ID < 1)
                throw new InvalidJobException("Invalid Id");

        }

    }
}
