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
            Type = TicketType.Task;
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
                $"Id: {Id}\nSummary: {Summary}\nStatus: {Status}\nPriority: {Priority}\nSubmitter: {Submitter}\nAssigned: {Assigned}\nWatching: {string.Join("|", Watching)}\nProject Name: {ProjectName}\nDue Date: {DueDate}";
        }

        public string ToDatabase()
        {
            return
                $"{Id},{Summary},{Status},{Priority},{Submitter},{Assigned},{string.Join("|", Watching)},{ProjectName},{DueDate}";
        }
    }
}