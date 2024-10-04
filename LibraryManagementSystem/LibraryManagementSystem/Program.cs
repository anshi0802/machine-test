using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManagementSystem
    {
        class Program
        {
            static void Main(string[] args)
            {
                IBooks library = new Books();
                bool keepRunning = true;

                while (keepRunning)
                {
                    try
                    {
                        Console.WriteLine("Library Management System");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("1. Add a Book");
                        Console.WriteLine("2. View Book Details");
                        Console.WriteLine("3. Exit");
                        Console.Write("Choose an option (1/2/3): ");
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                library.AddBooks();
                                break;
                            case 2:
                                library.GetBookDetails();
                                break;
                            case 3:
                                keepRunning = false;
                                Console.WriteLine("Exiting the application.");
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please choose 1, 2, or 3.\n");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
        }
    }
