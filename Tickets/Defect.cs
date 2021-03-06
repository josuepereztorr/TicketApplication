using System;
using TicketApplication.Enums;

namespace TicketApplication.Tickets
{
    public class Defect : Ticket
    {
        public Severity Severity { get; }
        
        //creates a new ticket given the summary, status, priority, submitter, and assigner 
        public Defect(string summary, Status status, Priority priority, Person submitter, Person assigned, Severity severity)
        {
            Type = TicketType.Defect;
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
                $"Id: {Id}\nType: {Type}\nSummary: {Summary}\nStatus: {Status}\nPriority: {Priority}\nSubmitter: {Submitter}\nAssigned: {Assigned}\nWatching: {string.Join("|", Watching)}\nSeverity: {Severity}";
        }

        public string ToDatabase()
        {
            return
                $"{Id},{Summary},{Status},{Priority},{Submitter},{Assigned},{string.Join("|", Watching)},{Severity}";
        }
        
        public static Defect ReadLine(string line)
        {
            //TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Severity
            string[] properties = line.Split(",");
            
            var defect = new Defect(properties[1], 
                Enum.Parse<Status>(properties[2]),
                Enum.Parse<Priority>(properties[3]),
                Ticket.CreatePerson(properties[4]),
                Ticket.CreatePerson(properties[5]),
                Enum.Parse<Severity>(properties[7]));
            
            defect.Id = Guid.Parse(properties[0]);
            defect.Watching = Ticket.CreateListOfWatchers(properties[6]);
            return defect;
        }
    }
}