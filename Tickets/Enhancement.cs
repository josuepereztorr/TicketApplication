using TicketApplication.Enums;

namespace TicketApplication.Tickets
{
    public class Enhancement : Ticket
    {
        public string Software { get; }
        public string Cost { get; }
        public string Reason { get; }
        public string Estimate { get; }
        
        //creates a new ticket given the summary, status, priority, submitter, and assigner 
        public Enhancement(string summary, Status status, Priority priority, Person submitter, Person assigned, string software, string cost, string reason, string estimate)
        {
            Type = TicketType.Enhancement;
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
                $"Id: {Id}\nSummary: {Summary}\nStatus: {Status}\nPriority: {Priority}\n Submitter: {Submitter}\nAssigned: {Assigned}\nWatching: {string.Join("|", Watching)}\nSoftware: {Software}\nCost: {Cost}\nReason: {Reason}\nEstimate: {Estimate}";
        }

        public string ToDatabase()
        {
            return
                $"{Id},{Summary},{Status},{Priority},{Submitter},{Assigned},{string.Join("|", Watching)},{Software},{Cost},{Reason},{Estimate}";
        }
    }
}