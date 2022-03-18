using System;
using System.Collections.Generic;

namespace TicketApplication
{
    public class Ticket
    {
        // FIELDS
        // unique Ticket ID 
        private readonly Guid _ticketId = Guid.NewGuid();
        // description of ticket 
        private readonly string _summary;
        // ticket Status
        private readonly Status _status;
        // ticket Priority
        private readonly Priority _priority;
        // Submit To 
        private readonly Person _submitter;
        // Assign To 
        private readonly Person _assigned;
        // Persons currently watching the ticket 
        private readonly List<Person> _watching = new List<Person>();
        
        // creates a new ticket given the summary, status, priority, submitter, and assigner 
        public Ticket(string summary, Status status, Priority priority, Person submitter, Person assigned)
        {
            //_ticketId = Guid.NewGuid();
            _summary = summary;
            _status = status;
            _priority = priority;
            _submitter = submitter;
            _assigned = assigned;
        }

        // adds people to watch the ticket 
        public void AddWatcher(Person watcher)
        {
            _watching.Add(watcher);
        }

        public string GetTicketId()
        {
            return _ticketId.ToString();
        }

        public override string ToString()
        {
            return
                $"{_ticketId},{_summary},{_status},{_priority},{_submitter},{_assigned},{string.Join("|", _watching)}";
        }
    }
    
}