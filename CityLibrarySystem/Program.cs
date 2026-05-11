using CityLibrarySystem.Context;
using Microsoft.EntityFrameworkCore;

namespace CityLibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region DataSead
            var dbcontext = new LibraryDbContext();
            //bool res = LibraryDBContextSeed.SeedData(dbcontext  );
            //if(res)
            //{
            //    Console.WriteLine("Data Seaded Sucessfully");
            //}
            //else
            //{
            //    Console.WriteLine("No Data Seaded");
            //}
            #endregion
            #region Data Manipulation
            // Retrieve the book title, its category title , and the author’s 
            //full name for all books whose price is greater than 300

            //var res = dbcontext.Books.Where(x => x.Price >= 300).Select(x => new
            //{
            //    x.Title,
            //    CategoryTitle = x.BookCategory.Title,
            //    AuthorFullName = (x.BookAuthor.FirstName ?? " ") + " " + (x.BookAuthor.LastName ?? " ")

            //});
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);

            //}

            //Retrieve All Authors And His/Her Books if Exists. 

            //var Author = dbcontext.Authors.Include(x => x.AuthorBooks).ToList();
            //foreach(var author in Author)
            //{
            //    Console.WriteLine(author.FirstName);
            //   foreach(var book in author.AuthorBooks)
            //    {
            //        Console.WriteLine(book.Title);
            //    }
            //    Console.WriteLine("---------");
            //}
            #endregion
        }
    }
}
