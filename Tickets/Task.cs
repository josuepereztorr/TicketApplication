using TicketApplication.Enums;

namespace TicketApplication.Tickets
{
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