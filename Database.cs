using System.Collections.Generic;
using System.IO;

namespace TicketApplication
{
    public class Database
    {
        // List of ticket objects from our database 
        private List<Ticket> _tickets;
        

        // constructor that initially reads the file and return all tickets (if it exists)
        public Database()
        {
            _tickets = new List<Ticket>();
        }
        

        // adds a ticket to the database
        public void AddTicket(Ticket ticket)
        {
            _tickets.Add(ticket);
        }
    }
}