using Domain.Enums;
using Domain.Exceptions;
using Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Job_Offer : BaseEntity<int>
    {
        public override int Id => JobId;
        public int JobId { get; private set; }// Immutable after creation
        public Employer employer { get; private set; } 
        public string JobName { get; private set; }
        public eJobType JobType { get; private set; }
        public int ReferenceNumber { get; private set; }
        public eIndustry Industry { get; private set; }
        public eWorkingHours WorkingHours { get; private set; }
        public DateTime EntryDate { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public DateTime? LastChangeDate { get; private set; }
        public int NumberOfApplicants { get; private set; }
        public SalaryRange SalaryRange { get; private set; }
        public string JobDescription { get; private set; }

        // Private constructor for EF Core or deserialization
        private Job_Offer() { }

        // Factory method for creating a new job
        public static Job_Offer Create(
            int employerId,
            string jobName,
            eJobType jobType,
            int referenceNumber,
            eIndustry industry,
            eWorkingHours workingHours,
            DateTime entryDate,
            SalaryRange salaryRange,
            string jobDescription)
        {
            ValidateInput(employerId, jobName, jobType, referenceNumber, industry, workingHours, entryDate, salaryRange, jobDescription);

            return new Job_Offer
            {
                EmployerId = employerId,
                JobName = jobName,
                JobType = jobType,
                ReferenceNumber = referenceNumber,
                Industry = industry,
                WorkingHours = workingHours,
                EntryDate = entryDate,
                ReleaseDate = DateTime.UtcNow, // Default to current UTC time
                LastChangeDate = null,
                NumberOfApplicants = 0, // Initialize with 0 applicants
                SalaryRange = salaryRange,
                JobDescription = jobDescription
            };
        }

        // Factory method for hydrating from database
        public static Job_Offer FromDatabase(
            int jobId,
            int employerId,
            string jobName,
            eJobType jobType,
            int referenceNumber,
            eIndustry industry,
            eWorkingHours workingHours,
            DateTime entryDate,
            DateTime releaseDate,
            DateTime? lastChangeDate,
            int numberOfApplicants,
            SalaryRange salaryRange,
            string jobDescription)
        {
            ValidateDatabaseInput(jobId, employerId, jobName, jobType, referenceNumber, industry,
                workingHours, entryDate, releaseDate, lastChangeDate, numberOfApplicants, salaryRange, jobDescription);

            return new Job_Offer
            {
                JobId = jobId,
                EmployerId = employerId,
                JobName = jobName,
                JobType = jobType,
                ReferenceNumber = referenceNumber,
                Industry = industry,
                WorkingHours = workingHours,
                EntryDate = entryDate,
                ReleaseDate = releaseDate,
                LastChangeDate = lastChangeDate,
                NumberOfApplicants = numberOfApplicants,
                SalaryRange = salaryRange,
                JobDescription = jobDescription
            };
        }

        public void Update(
            string jobName,
            eJobType jobType,
            int referenceNumber,
            eIndustry industry,
            eWorkingHours workingHours,
            SalaryRange salaryRange,
            string jobDescription)
        {
            ValidateUpdateInput(jobName, jobType, referenceNumber, industry, workingHours, salaryRange, jobDescription);

            JobName = jobName;
            JobType = jobType;
            ReferenceNumber = referenceNumber;
            Industry = industry;
            WorkingHours = workingHours;
            SalaryRange = salaryRange;
            JobDescription = jobDescription;
            LastChangeDate = DateTime.UtcNow;
        }

        public void IncrementApplicants() => NumberOfApplicants++;
        public void DecrementApplicants() => NumberOfApplicants = Math.Max(0, NumberOfApplicants - 1);

        // Validation
        private static void ValidateInput(
            int employerId,
            string jobName,
            eJobType jobType,
            int referenceNumber,
            eIndustry industry,
            eWorkingHours workingHours,
            DateTime entryDate,
            SalaryRange salaryRange,
            string jobDescription)
        {
            ValidateId(employerId);
            ValidateName(jobName);
            ValidateEnums(jobType, industry, workingHours);
            ValidateEntryDate(entryDate);
            ValidateSalary(salaryRange);
            ValidateDescription(jobDescription);
        }

        private static void ValidateDatabaseInput(int jobId,
            int employerId,
            string jobName,
            eJobType jobType,
            int referenceNumber,
            eIndustry industry,
            eWorkingHours workingHours,
            DateTime entryDate,
            DateTime releaseDate,
            DateTime? lastChangeDate,
            int numberOfApplicants,
            SalaryRange salaryRange,
            string jobDescription)
        {
            // Similar validation for database inputs
        }

        private static void ValidateUpdateInput(string jobName,
            eJobType jobType,
            int referenceNumber,
            eIndustry industry,
            eWorkingHours workingHours,
            SalaryRange salaryRange,
            string jobDescription)
        {
            // Validation specific to updates
        }

        private static void ValidateId(int id)
        {
            if (id < 1) 
                throw InvalidJobException.Invalid_ID(id);
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw InvalidJobException.MissingName();

            if (name.Trim().Length is < 5 or > 100)
                throw InvalidJobException.InvalidName(name);
        }

        private static void ValidateEnums(eJobType jobType, eIndustry industry, eWorkingHours workingHours)
        {
            if (!Enum.IsDefined(typeof(eJobType), jobType))
                throw InvalidJobException.InvalidEnum(jobType);

            if (!Enum.IsDefined(typeof(eIndustry), industry))
                throw InvalidJobException.InvalidEnum(industry);

            if (!Enum.IsDefined(typeof(eWorkingHours), workingHours))
                throw InvalidJobException.InvalidEnum(workingHours);
        }

        private static void ValidateEntryDate(DateTime entryDate)
        {
            if (entryDate > DateTime.UtcNow.AddDays(1))
                throw InvalidJobException.InvalidDate(entryDate);
        }

        private static void ValidateSalary(SalaryRange salary)
        {
            if (salary?.Minimum > salary?.Maximum)
                throw InvalidJobException.InvalidSalary(salary);
        }

        private static void ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description) || description.Length > 2000)
                throw InvalidJobException.InvalidDescription(description);
        }
        
    }
}