using System;
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

        public static Enhancement ReadLine(string line)
        {
            //TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Software, Cost, Reason, Estimate
            string[] properties = line.Split(",");
            
            var enhancement = new Enhancement(properties[1], 
                Enum.Parse<Status>(properties[2]),
                Enum.Parse<Priority>(properties[3]),
                Ticket.CreatePerson(properties[4]),
                Ticket.CreatePerson(properties[5]),
                properties[7],
                properties[8],
                properties[9],
                properties[10]);
            
            enhancement.Id = Guid.Parse(properties[0]);
            enhancement.Watching = Ticket.CreateListOfWatchers(properties[6]);
            return enhancement;
        }
        
        public override string ToString()
        {
            return
                $"Id: {Id}\nType: {Type}\nSummary: {Summary}\nStatus: {Status}\nPriority: {Priority}\nSubmitter: {Submitter}\nAssigned: {Assigned}\nWatching: {string.Join("|", Watching)}\nSoftware: {Software}\nCost: {Cost}\nReason: {Reason}\nEstimate: {Estimate}";
        }

        public string ToDatabase()
        {
            return
                $"{Id},{Summary},{Status},{Priority},{Submitter},{Assigned},{string.Join("|", Watching)},{Software},{Cost},{Reason},{Estimate}";
        }
    }
}