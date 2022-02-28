using System;
using System.IO;

namespace TicketApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;
            StreamWriter sw;

            Console.WriteLine("\nTicketing System\n" + new String('-', 16));

            do
            {
                Console.WriteLine("\n1) Create a Tickets.csv file from data.");
                Console.WriteLine("2) Add a new record.");
                Console.WriteLine("\nOr enter any other key to exit.");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        Console.WriteLine("Chose 2");break;
                }
            } while (choice is "1" or "2");
            
        }
    }
}