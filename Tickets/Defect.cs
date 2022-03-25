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
                $"Id: {Id}\nSummary: {Summary}\nStatus: {Status}\nPriority: {Priority}\nSubmitter: {Submitter}\nAssigned: {Assigned}\nWatching: {string.Join("|", Watching)}\nSeverity: {Severity}";
        }

        public string ToDatabase()
        {
            return
                $"{Id},{Summary},{Status},{Priority},{Submitter},{Assigned},{string.Join("|", Watching)},{Severity}";
        }
    }
}