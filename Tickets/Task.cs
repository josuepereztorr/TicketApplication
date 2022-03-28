using System;
using System.Collections.Generic;
using System.Linq;
using TicketApplication.Enums;

namespace TicketApplication.Tickets
{
    public class Task : Ticket
    {
        public string ProjectName { get; }
        public string DueDate { get; }
        
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
        
        public static Task ReadLine(string line)
        {
            //TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, ProjectName, DueDate
            string[] properties = line.Split(",");
            
            var task = new Task(properties[1], 
                Enum.Parse<Status>(properties[2]),
                Enum.Parse<Priority>(properties[3]),
                Ticket.CreatePerson(properties[4]),
                Ticket.CreatePerson(properties[5]),
                properties[7],
                properties[8]);
            
            task.Id = Guid.Parse(properties[0]);
            task.Watching = Ticket.CreateListOfWatchers(properties[6]);
            return task;
        }

        public override string ToString()
        {
            return
                $"Id: {Id}\nType: {Type}\nSummary: {Summary}\nStatus: {Status}\nPriority: {Priority}\nSubmitter: {Submitter}\nAssigned: {Assigned}\nWatching: {string.Join("|", Watching)}\nProject Name: {ProjectName}\nDue Date: {DueDate}";
        }

        public string ToDatabase()
        {
            return
                $"{Id},{Summary},{Status},{Priority},{Submitter},{Assigned},{string.Join("|", Watching)},{ProjectName},{DueDate}";
        }
    }
}