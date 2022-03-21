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
            Console.WriteLine("1) Create a CSV file from data.");
            Console.WriteLine("2) Add a new ticket.");
            Console.WriteLine("(or press enter to exit)");
            Console.Write("\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ValidationCheck("1");
                    return true;
                case "2":
                    ValidationCheck("2");
                    return true;
                default:
                    CloseProgram();
                    return false;
            }
        }

        private void ValidationCheck(string option)
        {
            // Ticket Type
            Console.Clear();
            Console.WriteLine("New Ticket Entry - TICKET_TYPE\n" + 
                              new string('-', 30) + "\n" + 
                              "Enter ticket summary: " +
                              "Choose a status option: \n" + 
                              "1) Defect\n" + "2) Enhancement\n" + "3) Task\n");
            Console.Write("\nSelect an option: ");
            string resp = Console.ReadLine();
            TicketType type = (TicketType) Int32.Parse(resp);
            //string option = resp;
            
            string file = type switch
            {
                TicketType.Defect => Filename.Defects,
                TicketType.Enhancement => Filename.Enhancements,
                TicketType.Task => Filename.Tasks,
                _ => ""
            };
            
            switch (option)
            {
                // for options 1 the file should not exist
                case "1":
                {
                    if (!File.Exists(file))
                    {
                        // set CreateTicket's fileExists to false
                        CreateTicket(false, type);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"New Ticket Entry - ERROR\n" + 
                                          new string('-', 24) + "\n" +
                                          "File already exists, this ticket will be appended to the created file" + 
                                          "\nPress enter to continue");
                        Console.ReadLine();
                        CreateTicket(true, type);
                    }

                    break;
                }
                case "2":
                {
                    if (File.Exists(file))
                    {
                        // set CreateTicket's fileExists to false
                        CreateTicket(true, type);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"New Ticket Entry - ERROR\n" + 
                                          new string('-', 24) + "\n" + 
                                          "No file exists, a new file will be created form the given data" + 
                                          "\nPress enter to continue");
                        Console.ReadLine();
                        CreateTicket(false, type);
                    }

                    break;
                }
            }
        }

        // returns a Ticket with all entries 
        private void CreateTicket(bool fileExists, TicketType type)
        {

            // SUMMARY 
            Console.Clear();
            Console.WriteLine("New Ticket Entry - SUMMARY\n" + 
                              new string('-', 26) + "\n");
            Console.Write("Enter ticket summary: ");
            string summary = Console.ReadLine();
            
            // STATUS
            Console.Clear();
            Console.WriteLine("New Ticket Entry - STATUS\n" + 
                              new string('-', 25) + "\n" + 
                              "Choose a status option: \n" + 
                              "1) Open\n" + "2) Closed\n" + "3) Pending\n" + "4) Solved\n");
            Console.Write("\nSelect an option: ");
            Status status = (Status) Int32.Parse(Console.ReadLine());

            // PRIORITY
            Console.Clear();
            Console.WriteLine("New Ticket Entry - PRIORITY\n" + 
                              new string('-', 27) + "\n" + 
                              "Choose a priority level: \n" + 
                              "1) Low\n" + "2) Normal\n" + "3) High\n" + "4) Critical\n");
            Console.Write("\nSelect an option: ");
            Priority priority = (Priority) Int32.Parse(Console.ReadLine());

            // SUBMITTER
            Console.Clear();
            Console.WriteLine("New Ticket Entry - SUBMITTER\n" + 
                              new string('-', 28) + "\n");
            Console.Write("Submitter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Submitter last name: ");
            string lastName = Console.ReadLine();
            var submitter = new Person(firstName, lastName);

            // ASSIGNER 
            Console.Clear();
            Console.WriteLine("New Ticket Entry - ASSIGNER\n" + 
                              new string('-', 27) + "\n");
            Console.Write("Assigner first name: ");
            firstName = Console.ReadLine();
            Console.Write("Assigner last name: ");
            lastName = Console.ReadLine();
            var assigner = new Person(firstName, lastName);

            // refactor: Use generics next time
            switch (type)
            {
                case TicketType.Defect:
                { 
                    Defect defect = InitDefect(summary, status, priority, submitter, assigner);
                    if (fileExists)
                    {
                        using StreamWriter writer = File.AppendText(Filename.Defects);
                        writer.WriteLine(defect.ToString());
                    }
                    else
                    {
                        using StreamWriter writer = File.CreateText(Filename.Defects);
                        writer.WriteLine(defect.ToString());
                    }
                    LoadingAnimation(defect);
                    break;
                }
                case TicketType.Enhancement:
                {
                    Enhancement enhancement = InitEnhancement(summary, status, priority, submitter, assigner);
                    LoadingAnimation(enhancement);
                    if (fileExists)
                    {
                        using StreamWriter writer = File.AppendText(Filename.Enhancements);
                        writer.WriteLine(enhancement.ToString());
                    }
                    else
                    {
                        using StreamWriter writer = File.CreateText(Filename.Enhancements);
                        writer.WriteLine(enhancement.ToString());
                    }
                    break;
                }
                case TicketType.Task:
                {
                    Task task = InitTask(summary, status, priority, submitter, assigner);
                    LoadingAnimation(task);
                    if (fileExists)
                    {
                        using StreamWriter writer = File.AppendText(Filename.Tasks);
                        writer.WriteLine(task.ToString());
                    }
                    else
                    {
                        using StreamWriter writer = File.CreateText(Filename.Tasks);
                        writer.WriteLine(task.ToString());
                    }
                    break;
                }
            }

        }

        private Defect InitDefect(string summary, Status status, Priority priority, Person submitter, Person assigner)
        {
            // SEVERITY
            Console.Clear();
            Console.WriteLine("New Ticket Entry - SEVERITY\n" + 
                              new string('-', 27) + "\n" + 
                              "Choose a severity level: \n" + 
                              "1) Level 1\n" + "2) Level 2\n" + "3) Level 3\n" + "4) Level 4\n" + "5) Level 5\n ");
            Console.Write("\nSelect an option: ");
            Severity severity = (Severity) Int32.Parse(Console.ReadLine());
            
            Defect defect = new Defect(summary, status, priority, submitter, assigner, severity);
            AddWatchersToTicket(defect);
            return defect;
        }

        private Enhancement InitEnhancement(string summary, Status status, Priority priority, Person submitter, Person assigner)
        {
            // SOFTWARE
            Console.Clear();
            Console.WriteLine("New Ticket Entry - SOFTWARE\n" + 
                              new string('-', 27) + "\n");
            Console.Write("Enter software used: ");
            string software = Console.ReadLine();
                
            // COST 
            Console.Clear();
            Console.WriteLine("New Ticket Entry - COST\n" + 
                              new string('-', 23) + "\n");
            Console.Write("Enter cost: $ ");
            string cost = Console.ReadLine();
                
            // REASON
            Console.Clear();
            Console.WriteLine("New Ticket Entry - REASON\n" + 
                              new string('-', 24) + "\n");
            Console.Write("Enter reason: ");
            string reason = Console.ReadLine();    
                
            // ESTIMATE 
            Console.Clear();
            Console.WriteLine("New Ticket Entry - ESTIMATE\n" + 
                              new string('-', 27) + "\n");
            Console.Write("Enter estimate: $ ");
            string estimate = Console.ReadLine();  

            Enhancement enhancement = new Enhancement(summary, status, priority, submitter, assigner, software, cost, reason, estimate);
            AddWatchersToTicket(enhancement);
            return enhancement;
        }

        private Task InitTask(string summary, Status status, Priority priority, Person submitter, Person assigner)
        {
            // PROJECT NAME
            Console.Clear();
            Console.WriteLine("New Ticket Entry - PROJECT_NAME\n" + 
                              new string('-', 31) + "\n");
            Console.Write("Enter the project name: ");
            string projectName = Console.ReadLine();
                
            // DUE DATE 
            Console.Clear();
            Console.WriteLine("New Ticket Entry - DUE_DATE\n" + 
                              new string('-', 27) + "\n");
            Console.Write("Enter due date (MM/DD/YYYY): ");
            string dueDate = Console.ReadLine();

            Task task = new Task(summary, status, priority, submitter, assigner, projectName, dueDate);
            AddWatchersToTicket(task);
            return task;
        }

        private void AddWatchersToTicket(Ticket ticket)
        {
            // WATCHER(S)
            Console.Clear();
            Console.WriteLine("New Ticket Entry - WATCHING\n" + 
                              new string('-', 27) + "\n" +
                              "Are there any people watching this ticket (y/n)? ");
            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();
            
            while (choice == "y")
            {
                Console.Clear();
                Console.WriteLine("New Ticket Entry - WATCHING\n" + new string('-', 27) + "\n");
                    
                Console.Write("Watcher first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Watcher last name: ");
                string lastName = Console.ReadLine();
                Person watcher = new Person(firstName, lastName);
                ticket.AddWatcher(watcher);
                    
                Console.WriteLine("\nWant to add another watcher to this ticket (y/n)? ");
                Console.Write("\nSelect an option: ");
                choice = Console.ReadLine();
            
            }
        }

        private void LoadingAnimation(Ticket ticket) {
            UtilityMethods.Loading(ticket,$"Creating Ticket", 300);
            UtilityMethods.Loading(ticket,$"Adding Ticket", 300);
            UtilityMethods.Loading(ticket,$"Writing to File", 300);
            
            Console.WriteLine($"New Ticket Entry - Add to File\n" + new string('-', 30) + "\n");
            Console.WriteLine("Ticket #" + ticket.GetTicketId());
            Console.WriteLine($"Successfully Added");
            Console.Write("\nPress enter to continue");
            Console.ReadLine();
        }
        
        private static void CloseProgram()
        {
            Console.Clear();
            Console.WriteLine("\nTicketing Management Application\n" + new string('-', 32) + "\n");
            Console.WriteLine("Application Successfully Closed..");
        }
    }
}