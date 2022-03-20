using System;
using System.Collections.Generic;
using TicketApplication.Enums;

namespace TicketApplication.Tickets
{
    public abstract class Ticket
    {
        // FIELDS
        // unique Ticket ID 
        public Guid Id { get; set; }
        // description of ticket 
        public string Summary { get; set; }
        // ticket Status
        public Status Status { get; set; }
        // ticket Priority
        public Priority Priority { get; set; }
        // Submit To 
        public Person Submitter { get; set; }
        // Assign To 
        public Person Assigned { get; set; }

        // Persons currently watching the ticket 
        public List<Person> Watching { get; set; }
        
        public Ticket()
        {
            Id = Guid.NewGuid();
            Watching = new List<Person>();
        }

        // adds people to watch the ticket 
        public void AddWatcher(Person watcher)
        {
            Watching.Add(watcher);
        }

        public string GetTicketId()
        {
            return Id.ToString();
        }

        public new virtual string ToString()
        {
            return
                $"{Id},{Summary},{Status},{Priority},{Submitter},{Assigned},{string.Join("|", Watching)}";
        }
    }

}