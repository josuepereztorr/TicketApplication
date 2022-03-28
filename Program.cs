using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using TicketApplication.Enums;
using TicketApplication.Tickets;

namespace TicketApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            DatabaseService service = new DatabaseService();
            bool runApp = true;
            
            while (runApp)
            {
                runApp = service.Menu();
            }
        }
    }
}