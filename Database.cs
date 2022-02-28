using System.Collections.Generic;

namespace TicketApplication
{
    public class Database
    {
        private List<Ticket> _tickets= new List<Ticket>();

        public List<Ticket> GetTicket()
        {
            return _tickets;
        }

        public void AddTicket(Ticket ticket)
        {
            _tickets.Add(ticket);
        }
    }
}