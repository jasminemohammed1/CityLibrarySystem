using CityLibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CityLibrarySystem.Context
{
    internal static class LibraryDBContextSeed
    {
        private static List<T> LoadDataFromJson<T>(string path)
        {
            if(!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            string data = File.ReadAllText(path);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            options.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Deserialize<List<T>>(data, options) ?? new List<T>();
        }

        public static bool SeedData(LibraryDbContext dbContext)
        {
            var tran = dbContext.Database.BeginTransaction();
            try
            {
                bool hasAuthors = dbContext.Authors.Any();
                bool hasCategories = dbContext.Categories.Any();
                bool hasBooks = dbContext.Books.Any();
                bool hasMembers = dbContext.Members.Any();
                if (hasAuthors && hasCategories && hasBooks && hasMembers) return false;
                if(!hasAuthors)
                {
                    var authors = LoadDataFromJson<Author>("files/Authors.json");
                    dbContext.AddRange(authors);
                }
                if(!hasCategories)
                {
                    var categories = LoadDataFromJson<Category>("files/Categories.json");
                    dbContext.Categories.AddRange(categories);
                }
                dbContext.SaveChanges();
                if(!hasBooks)
                {
                    var authors = dbContext.Authors
                                   .OrderBy(x => x.Id)
                                   .ToList();
                    var books = LoadDataFromJson<Book>("files/Books.json");
                    foreach (var item in books)
                    {
                        var authorId = item.AuthorId;
                        item.AuthorId = authors[authorId - 1].Id;

                        
                    }
                    dbContext.Books.AddRange(books);
                }
                if(!hasMembers)
                {
                    var members = LoadDataFromJson<Member>("files/Members.json");
                    dbContext.Members.AddRange(members);
                }
                dbContext.SaveChanges();
                tran.Commit();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                tran.Rollback();
                return false;
            }

        }
    }
}
