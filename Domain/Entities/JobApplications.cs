using Domain.Enums;
using Domain.Exceptions;
using System.Globalization;

namespace Domain.Entities
{
    public class JobApplications:BaseEntity<int>
    {
        public override int Id => Application_ID;
        public int Application_ID { get; private set; }
        public int Job_ID { get; private set; }
        public int Employers_ID { get; private set; }
        public int Employee_ID { get; private set; }
        public DateTime Application_Date { get; private set; }
        public eApplicationsStatus Status { get; private set; }

        private JobApplications()
        {
            Application_ID = default!;
            Job_ID = default!;
            Employers_ID = default!;
            Employee_ID = default!;
            Application_Date = default!;
            Status = default!;
        }

        private JobApplications(int application_ID, int job_ID, int employers_ID, int employee_ID, DateTime application_Date,
                                eApplicationsStatus status)
        {
            ValidateID(application_ID);
            ValidateID(job_ID);
            ValidateID(employee_ID);
            ValidateID(employers_ID);
            ValidateApplicationDate(application_Date);
            ValidateStatus(status);
            Application_ID = application_ID;
            Job_ID = job_ID;
            Employers_ID = employers_ID;
            Employee_ID = employee_ID;
            Application_Date = application_Date;
            Status = status;
        }

        private JobApplications(int job_ID, int employers_ID, int employee_ID, DateTime application_Date, eApplicationsStatus status)
        {
            ValidateID(job_ID);
            ValidateID(employee_ID);
            ValidateID(employers_ID);
            ValidateApplicationDate(application_Date);
            ValidateStatus(status);
            Job_ID = job_ID;
            Employers_ID = employers_ID;
            Employee_ID = employee_ID;
            Application_Date = application_Date;
            Status = status;
        }

        public static JobApplications FromDatabase(int application_ID, int job_ID, int employers_ID, int employee_ID, DateTime application_Date,
                                                    eApplicationsStatus status)
        {

            return new JobApplications(application_ID, job_ID, employers_ID, employee_ID, application_Date, status);

        }
        public static JobApplications CreateApplication(int job_ID, int employers_ID, int employee_ID, DateTime application_Date,
                                                        eApplicationsStatus status)
        {
            return new JobApplications(job_ID, employers_ID, employee_ID, application_Date, status);


        }
        public void UpdateStatus(eApplicationsStatus status)
        {
            ValidateStatus(status);
            Status = status;
        }
        private void ValidateID(int id)
        {
            if (id < 1)
                throw new InvalidJobApplicationException("Invalid ID");
        }
        private void ValidateApplicationDate(DateTime newDate)
        {
            if (newDate > DateTime.Now)
                throw new InvalidJobApplicationException("Application cant be in the future");
            if (newDate < DateTime.Now.AddYears(-120))
                throw new InvalidPersonException("Invalid date");
        }
        private void ValidateStatus(eApplicationsStatus status)
        {
            if (!Enum.IsDefined(typeof(eApplicationsStatus), status))
                throw new InvalidJobApplicationException("Invalid Status");


        }


    }
}
