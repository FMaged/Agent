using Domain.Enums;
using System.Globalization;

namespace Domain.Entities
{
    public class JobApplications
    {
        public int Application_ID { get;}
        public int Job_ID { get;}
        public int Employers_ID { get;}
        public int Employee_ID { get;}
        public DateTime Application_Date { get; set; }
        public eApplicationsStatus Status { get; set; }

        public JobApplications(int application_ID, int job_ID, int employers_ID, int employee_ID, DateTime application_Date, 
                                eApplicationsStatus status)
        {
            Application_ID = application_ID;
            Job_ID = job_ID;
            Employers_ID = employers_ID;
            Employee_ID = employee_ID;
            Application_Date = application_Date;
            Status = status;
        }

        public JobApplications(int job_ID, int employers_ID, int employee_ID, DateTime application_Date, eApplicationsStatus status)
        {

            Job_ID = job_ID;
            Employers_ID = employers_ID;
            Employee_ID = employee_ID;
            Application_Date = application_Date;
            Status = status;
        }
    }
}
