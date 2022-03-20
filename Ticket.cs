using System;
using System.Collections.Generic;
using TicketApplication.Enums;

namespace TicketApplication
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

    public class Defect : Ticket
    {
        public Severity Severity { get; }
        
        //creates a new ticket given the summary, status, priority, submitter, and assigner 
        public Defect(string summary, Status status, Priority priority, Person submitter, Person assigned, Severity severity)
        {
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Severity = severity;
        }
        
        public override string ToString()
        {
            return
                $"{Id},{Summary},{Status},{Priority},{Submitter},{Assigned},{string.Join("|", Watching)},{Severity}";
        }
    }

    public class Enhancement : Ticket
    {
        public string Software { get; }
        public float Cost { get; }
        public string Reason { get; }
        public float Estimate { get; }
        
        //creates a new ticket given the summary, status, priority, submitter, and assigner 
        public Enhancement(string summary, Status status, Priority priority, Person submitter, Person assigned, string software, float cost, string reason, float estimate)
        {
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Software = software;
            Cost = cost;
            Reason = reason;
            Estimate = estimate;
        }
        
        public override string ToString()
        {
            return
                $"{Id},{Summary},{Status},{Priority},{Submitter},{Assigned},{string.Join("|", Watching)},{Software},{Cost},{Reason},{Estimate}";
        }
    }

    public class Task : Ticket
    {
        public string ProjectName { get; }
        public string DueDate { get; }

        //creates a new ticket given the summary, status, priority, submitter, and assigner 
        public Task(string summary, Status status, Priority priority, Person submitter, Person assigned, string projectName, string dueDate)
        {
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            ProjectName = projectName;
            DueDate = dueDate;
        }
        
        public override string ToString()
        {
            return
                $"{Id},{Summary},{Status},{Priority},{Submitter},{Assigned},{string.Join("|", Watching)},{ProjectName},{DueDate}";
        }
    }
    
}