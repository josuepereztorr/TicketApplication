using System;
using System.Threading;
using TicketApplication.Tickets;

namespace TicketApplication
{
    public static class UtilityMethods
    {
        public static void Loading(Ticket ticket, string message, int milliseconds)
        {
            const string loading = "...";

            for (int j = 0; j < 2; j++)
            {
                Console.Clear();
                Console.WriteLine($"New Ticket Entry - Add to File\n" + new string('-', 30) + "\n");

                Console.WriteLine("Ticket #" + ticket.GetTicketId());
                Console.Write(message);

                foreach (var dot in loading)
                {
                    Console.Write(dot);
                    Thread.Sleep(milliseconds);
                }

                Console.Clear();
            }
        }

    }
}