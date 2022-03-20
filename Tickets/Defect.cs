using TicketApplication.Enums;

namespace TicketApplication.Tickets
{
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
}