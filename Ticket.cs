using System;
using System.Collections.Generic;

namespace TicketApplication
{
    public class Ticket
    {

        private Guid _ticketId;
        public string Summary { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        private Person _submitter;
        private Person _assigned;
        private readonly List<Person> _watching = new List<Person>();

        public Ticket(string summary)
        {
            _ticketId = Guid.NewGuid();
            Summary = summary;
        }

        public string GetGuid()
        {
            return _ticketId.ToString();
        }

        public void SetSubmitter(string firstName, string lastName)
        {
            Person submitter = new Person(firstName, lastName);
            _submitter = submitter;
        }

        public Person GetSubmitter()
        {
            return _submitter;
        }

        public void SetAssigned(string firstName, string lastName)
        {
            Person assigned = new Person(firstName, lastName);
            _assigned = assigned;
        }

        public Person GetAssigned()
        {
            return _assigned;
        }
        
        public void AddWatcher(string firstName, string lastName)
        {
            Person watcher = new Person(firstName, lastName);
            _watching.Add(watcher);
        }

        public List<Person> GetWatchers()
        {
            return _watching;
        }
    }
}