using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class JobApplications:BaseEntity<int>
    {
        public override int Id => Application_ID;
        public int Application_ID { get; private set; }
        public Job_Offer jobOffer { get; private set; }
        public Employer employer { get; private set; }
        public Employee employee { get; private set; }
        public DateTime Application_Date { get; private set; }
        public eApplicationsStatus Status { get; private set; }

        private JobApplications()
        {
            Application_ID = default!;
            jobOffer = default!;
            employer = default!;
            employee = default!;
            Application_Date = default!;
            Status = default!;
        }

        private JobApplications(int application_ID, Job_Offer job, Employer EMployer, Employee employee, DateTime application_Date,
                                eApplicationsStatus status)
        {
            ValidateID(application_ID);
            ValidateApplicationDate(application_Date);
            ValidateStatus(status);
            Application_ID = application_ID;
            jobOffer = job;
            employer = EMployer;
            this.employee = employee;
            Application_Date = application_Date;
            Status = status;
        }

        private JobApplications(Job_Offer job, Employer EMployer, Employee EMployee, DateTime application_Date, eApplicationsStatus status)
        {
            ValidateApplicationDate(application_Date);
            ValidateStatus(status);
            jobOffer = job;
            employer = EMployer;
            employee = EMployee;
            Application_Date = application_Date;
            Status = status;
        }

        public static JobApplications FromDatabase(int application_ID, Job_Offer job_ID, Employer employers_ID, Employee employee_ID, DateTime application_Date,
                                                    eApplicationsStatus status)
        {

            return new JobApplications(application_ID, job_ID, employers_ID, employee_ID, application_Date, status);

        }
        public static JobApplications CreateApplication(Job_Offer job_ID, Employer employers_ID, Employee employee_ID, DateTime application_Date,
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
                throw DomainException.Invalid_ID(id);
        }
        private void ValidateApplicationDate(DateTime newDate)
        {
            if (newDate > DateTime.Now)
                throw InvalidJobApplicationException.InvalidDate(newDate);
            if (newDate < DateTime.Now.AddYears(-120))
                throw InvalidJobApplicationException.InvalidDate(newDate);
        }
        private void ValidateStatus(eApplicationsStatus status)
        {
            if (!Enum.IsDefined(typeof(eApplicationsStatus), status))
                throw InvalidJobApplicationException.InvalidStatus();


        }


    }
}
