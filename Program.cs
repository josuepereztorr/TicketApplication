using System;
using System.Collections.Generic;
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

                if (choice == "1")
                {
                    if (!File.Exists(file))
                    {
                        Ticket ticket = GenerateTicket();
                        using (StreamWriter writer = File.AppendText(file))
                        {
                            writer.WriteLine(ticket.ToString());
                            Console.WriteLine(ticket.ToString());
                            Console.WriteLine("File successfully created and record added");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nError: File already exists, to add a new ticket select option #2 in the main menu");
                    }
                } else if (choice == "2")
                {
                    if (File.Exists(file))
                    {
                        Ticket ticket = GenerateTicket();
                        using (StreamWriter writer = File.AppendText(file))
                        {
                            writer.WriteLine(ticket.ToString());
                            Console.WriteLine(ticket.ToString());
                            Console.WriteLine("File successfully created and record added");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nError: No file exits, please create a new file in order to add a new ticket.");
                    }
                }
            } while (choice is "1" or "2");
            
        }

        static Ticket GenerateTicket()
        {
            Console.WriteLine("\nTicket\n------");
                        Console.Write("Summary: ");
                        string summary = Console.ReadLine();
                        Console.WriteLine("Select the status of this ticket: ");
                        Console.WriteLine("1) Open");
                        Console.WriteLine("2) Closed");
                        Console.WriteLine("3) Pending");
                        Console.WriteLine("4) Solved");
                        int num = Int32.Parse(Console.ReadLine());
                        Status status = new Status(); 
                        switch (num)
                        {
                            case 1:
                                status = Status.Open;
                                break;
                            case 2:
                                status = Status.Closed;
                                break;
                            case 3:
                                status = Status.Pending;
                                break;
                            case 4:
                                status = Status.Solved;
                                break;
                        }
                
                        Console.WriteLine("Select the priority of this ticket: ");
                        Console.WriteLine("1) Low");
                        Console.WriteLine("2) Normal");
                        Console.WriteLine("3) High");
                        Console.WriteLine("4) Critical");
                        num = Int32.Parse(Console.ReadLine());
                        Priority priority = new Priority();
                        switch (num)
                        {
                            case 1:
                                priority = Priority.Low;
                                break;
                            case 2:
                                priority = Priority.Normal;
                                break;
                            case 3:
                                priority = Priority.High;
                                break;
                            case 4:
                                priority = Priority.Critical;
                                break;
                        }

                        Console.WriteLine("What is the first name of the Submitter of this ticket?");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("What is the last name of the Submitter of this ticket?");
                        string lastName = Console.ReadLine();
                        Person submitter = new Person(firstName, lastName);
                        Console.WriteLine("What is the first name of the person that is Assigned to this ticket?");
                        firstName = Console.ReadLine();
                        Console.WriteLine("What is the last name of the person that is Assigned to this ticket?");
                        lastName = Console.ReadLine();
                        Person assigned = new Person(firstName, lastName);

                        List<Person> watching = new List<Person>();
                        Console.WriteLine("Add a watcher to this ticket? (y/n)");
                        string yesOrNo;
                        do
                        {
                            yesOrNo = Console.ReadLine();

                            if (yesOrNo == "y")
                            {
                                Console.WriteLine("Person's first name");
                                firstName = Console.ReadLine();
                                Console.WriteLine("Person's last name");
                                lastName = Console.ReadLine();
                                watching.Add(new Person(firstName, lastName));
                            }
                            
                            Console.WriteLine("Add another watcher to this ticket? (y/n)");

                        } while (yesOrNo != "n");

                        return new Ticket(summary, status, priority, submitter, assigned, watching);
        }
    }
}