using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class Books : IBooks
    {
        private Dictionary<int, Book> bookDictionary = new Dictionary<int, Book>();

        public void AddBooks()
        {
            try
            {
                Console.Write("Enter Book ID: ");
                int id = int.Parse(Console.ReadLine());

                if (bookDictionary.ContainsKey(id))
                {
                    Console.WriteLine("Book with this ID already exists.\n");
                    return;
                }

                Console.Write("Enter Book Name: ");
                string name = Console.ReadLine();

                // Display category options to the user
                Console.WriteLine("Choose a Category: ");
                foreach (var category in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine($"{(int)category} - {category}");
                }

                // Get user's category choice
                Console.Write("Enter the number corresponding to the category: ");
                int categoryChoice = int.Parse(Console.ReadLine());

                // Validate the selected category
                if (!Enum.IsDefined(typeof(Category), categoryChoice))
                {
                    Console.WriteLine("Invalid category selection. Please try again.\n");
                    return;
                }

                // Convert user's selection to the corresponding Category enum
                Category selectedCategory = (Category)categoryChoice;

                // Add the book details to the dictionary
                bookDictionary.Add(id, new Book { BookID = id, BookName = name, BookCategory = selectedCategory });
                Console.WriteLine("Book added successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void GetBookDetails()
        {
            if (bookDictionary.Count == 0)
            {
                Console.WriteLine("No books available in the library.\n");
                return;
            }

            Console.WriteLine("Library Books:");
            foreach (var book in bookDictionary.Values)
            {
                Console.WriteLine($"ID: {book.BookID}, Name: {book.BookName}, Category: {book.BookCategory}");
            }
            Console.WriteLine();
        }
    }
}