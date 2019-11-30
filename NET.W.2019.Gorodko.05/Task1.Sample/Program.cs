using System;
using Task1.Domain;
using Task1.Service;
using Task1.Storage;

namespace Task1.Sample
{
    public class Program
    {
        static void Main(string[] args)
        {
            var service = new BookListService(BookListStorage.Instance);
            service.Save();

            var books = new Book[9];

            books[0] = new Book("1234567890121", "Author1", "Title1", "Publisher1", 1, 1, 1);
            books[1] = new Book("1234567890122", "Author2", "Title2", "Publisher1", 1, 1, 1);
            books[2] = new Book("1234567890123", "Author3", "Title3", "Publisher2", 1, 1, 1);
            books[3] = new Book("1234567890124", "Author1", "Title4", "Publisher2", 1, 1, 1);
            books[4] = new Book("1234567890125", "Author2", "Title5", "Publisher3", 1, 1, 1);
            books[5] = new Book("1234567890126", "Author3", "Title6", "Publisher3", 1, 1, 1);
            books[6] = new Book("1234567890127", "Author4", "Title1", "Publisher4", 1, 1, 1);
            books[7] = new Book("1234567890128", "Author1", "Title2", "Publisher4", 1, 1, 1);
            books[8] = new Book("1234567890129", "Author5", "Title3", "Publisher4", 1, 1, 1);

            foreach (var book in books)
            {
                service.AddBook(book);
            }

            service.Save();

            var newService = new BookListService(BookListStorage.Instance);

            foreach (var item in newService.Load().FindBooksByTag(books[1], Book.Tag.ISBN))
            {
                Console.WriteLine(item.ISBN);
            }

            Console.WriteLine("----------------------------------------");
            foreach (var item in newService.FindBooksByTag(books[1], Book.Tag.Author))
            {
                Console.WriteLine(item.ISBN);
            }

            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < newService.CountOfBooks; i++)
            {
                Console.WriteLine(newService[i].Author);
            }

            Console.WriteLine("---------------------------------------");

            newService.SortBooksByTag(Book.Tag.Author);

            for (int i = 0; i < newService.CountOfBooks; i++)
            {
                Console.WriteLine(newService[i].Author);
            }

            newService.Save();
            foreach (var book in books)
            {
                newService.RemoveBook(book);
            }
        }
    }
}
