using System;
using System.Collections.Generic;
using System.Linq;
using TicketApplication.Enums;

namespace TicketApplication.Tickets
{
    public abstract class Ticket
    {
        // FIELDS
        // unique Ticket ID 
        public Guid Id { get; set; }
        // ticket type
        public TicketType Type { get; set; }

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

        public static Person CreatePerson(string person)
        {
            string[] name = person.Split(" ");
            return new Person(name[0], name[1]);
        }

        public static List<Person> CreateListOfWatchers(string watchers)
        {
            List<Person> persons = new List<Person>();
            watchers.Split("|").ToList().ForEach(w =>
            {
                persons.Add(CreatePerson(w));
            });

            return persons;
        }
        
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
                $"Id: {Id}\nSummary: {Summary}\n Status: {Status}\nPriority: {Priority}\n Submitter{Submitter}\nAssigned: {Assigned}\nWatching{string.Join("|", Watching)}";
        }
    }

}