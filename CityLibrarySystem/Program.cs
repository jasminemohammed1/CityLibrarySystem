using CityLibrarySystem.Context;

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
        }
    }
}
