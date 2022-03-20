using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using TicketApplication.Enums;
using TicketApplication.Tickets;

namespace TicketApplication
{
    public class DatabaseService
    {

        // print menu options
        public bool Menu()
        {

            // clear console and print menu
            Console.Clear();
            Console.WriteLine("\nTicketing Management Application\n" + new string('-', 32) + "\n");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Create a Tickets.csv file from data.");
            Console.WriteLine("2) Add a new ticket.");
            Console.WriteLine("(or press enter to exit)");
            Console.Write("\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    WriteTicket(Filename.Tickets, false);
                    return true;
                case "2":
                    WriteTicket(Filename.Tickets,true);
                    return true;
                default:
                    CloseProgram();
                    return false;
            }
        }
        
        //writes a Ticket object to the given filename
        private void WriteTicket(string filename, bool fileExists)
        {
            if (!fileExists)
            {
                if (!File.Exists(filename))
                {
                    using StreamWriter writer = File.CreateText(filename);
                    Ticket ticket = NewEntry();
                    writer.WriteLine(ticket.ToString());
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"New Ticket Entry - ERROR\n" + new string('-', 24) + "\n");
                    Console.WriteLine("File already exists, try to add a new ticket to the created file.");
                    Console.Write("\nPress enter to continue");
                    Console.ReadLine();
                }
            }
            else
            {
                if (File.Exists(filename))
                {
                    using StreamWriter writer = File.AppendText(filename);
                    Ticket ticket = NewEntry();
                    writer.WriteLine(ticket.ToString());
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"New Ticket Entry - ERROR\n" + new string('-', 24) + "\n");
                    Console.WriteLine("File does not exists, try to create a new file first.");
                    Console.Write("\nPress enter to continue");
                    Console.ReadLine();
                }
            }
        }

        // returns a Ticket with all entries 
        private Ticket NewEntry()
        {

            // SUMMARY 
            Console.Clear();
            Console.WriteLine("New Ticket Entry - SUMMARY\n" + 
                              new string('-', 26) + "\n" + "Enter ticket summary: ");
            string summary = Console.ReadLine();
            
            // STATUS
            Console.Clear();
            Console.WriteLine("New Ticket Entry - STATUS\n" + 
                              new string('-', 25) + "\n" + 
                              "Choose a status option: " + 
                              "1) Open\n" + "2) Closed\n" + "3) Pending\n" + "4) Solved\n" + 
                              "\nSelect an option: ");

            Status status = (Status) Int32.Parse(Console.ReadLine());

            // PRIORITY
            Console.Clear();
            Console.WriteLine("New Ticket Entry - PRIORITY\n" + 
                              new string('-', 27) + "\n" + 
                              "Choose a priority level: " + 
                              "1) Low\n" + "2) Normal\n" + "3) High\n" + "4) Critical\n" +
                              "\nSelect an option: ");

            Priority priority = (Priority) Int32.Parse(Console.ReadLine());

            // SUBMITTER
            Console.Clear();
            Console.WriteLine("New Ticket Entry - SUBMITTER\n" + 
                              new string('-', 28) + "\n" + 
                              "Submitter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Submitter last name: ");
            string lastName = Console.ReadLine();
            var submitter = new Person(firstName, lastName);

            // ASSIGNER 
            Console.Clear();
            Console.WriteLine("New Ticket Entry - ASSIGNER\n" + 
                              new string('-', 27) + "\n" + 
                              "Assigner first name: ");
            firstName = Console.ReadLine();
            Console.Write("Assigner last name: ");
            lastName = Console.ReadLine();
            var assigner = new Person(firstName, lastName);

            // WATCHER(S)
            Console.Clear();
            Console.WriteLine("New Ticket Entry - WATCHING\n" + 
                              new string('-', 27) + "\n" +
                              "Are there any people watching this ticket (y/n)? " + 
                              "\nSelect an option: ");
            string choice = Console.ReadLine();

            // if (choice == "n")
            // {
            //     return ticket; 
            // }
            
            while (choice == "y")
            {
                Console.Clear();
                Console.WriteLine("New Ticket Entry - WATCHING\n" + new string('-', 27) + "\n");
                    
                Console.Write("Watcher first name: ");
                firstName = Console.ReadLine();
                Console.Write("Watcher last name: ");
                lastName = Console.ReadLine();
                Person watcher = new Person(firstName, lastName);
                //ticket.AddWatcher(watcher);
                    
                Console.WriteLine("\nWant to add another watcher to this ticket (y/n)? ");
                Console.Write("\nSelect an option: ");
                choice = Console.ReadLine();

            }

            // --------------------------------------
            
            // SEVERITY
            Console.Clear();
            Console.WriteLine("New Ticket Entry - SEVERITY\n" + new string('-', 27) + "\n");

            Severity severity = Severity.Level1;
            Console.WriteLine("Choose a severity level: ");
            Console.WriteLine("1) Level 1\n" + "2) Level 2\n" + "3) Level 3\n" + "4) Level 4\n" + "5) Level 5\n ");
            Console.Write("\nSelect an option: ");
            severity = Console.ReadLine() switch
            {
                "1" => Severity.Level1,
                "2" => Severity.Level2,
                "3" => Severity.Level3,
                "4" => Severity.Level4,
                _ => severity
            };
            
            Defect ticket = new Defect(summary, status, priority, submitter, assigner, severity);
            
            UtilityMethods.Loading(ticket,$"Creating Ticket", 300);
            UtilityMethods.Loading(ticket,$"Adding Ticket", 300);
            UtilityMethods.Loading(ticket,$"Writing to File", 300);
            
            Console.WriteLine($"New Ticket Entry - Add to File\n" + new string('-', 30) + "\n");
            Console.WriteLine("Ticket #" + ticket.GetTicketId());
            Console.WriteLine($"Successfully Added");
            Console.Write("\nPress enter to continue");
            Console.ReadLine();

            return ticket;
        }

        // prints out ending statement
        private static void CloseProgram()
        {
            Console.Clear();
            Console.WriteLine("\nTicketing Management Application\n" + new string('-', 32) + "\n");
            Console.WriteLine("Application Successfully Closed..");
        }
    }
}