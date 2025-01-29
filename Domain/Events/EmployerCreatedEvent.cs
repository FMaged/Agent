using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class EmployerCreatedEvent:DomainEvent
    {
        public Employer CreatedEmployer { get; }

        // Required for serialization
        protected EmployerCreatedEvent() { }
        public EmployerCreatedEvent(Employer employer)
        {
            CreatedEmployer = employer;
        }



        /// <summary>
        /// Returns a string representation of the event
        /// </summary>
        public override string ToString()
        {
            return $"Employer Created [ID: {CreatedEmployer.Id}, Name: {CreatedEmployer.Company_Name}]";
        }
    }
}
