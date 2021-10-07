using System;
using System.Linq;
using EFdatabase.Models;

namespace EFdatabase
{
    internal class Program
    {
        private static void Main()
        {
            using (var db = new BabyContext())
            {
                // Note: This sample requires the database to be created before running.
                Console.WriteLine($"Database path: {db.DbPath}.");
                
                // Create
                Console.WriteLine("Inserting a new action");
                db.Add(new Poo 
                    {    
                        Date="7/10/2021",  
                        Time= "21:42", 
                        Color="yellow", 
                        Quality="good",
                        Delivery="easy"
                    });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Poo
                    .OrderBy(b => b.Id)
                    .First();
                for (int i = 0; i<2; i++){
                    Console.WriteLine(db.Poo);
                }
                

                // Update
                /*Console.WriteLine("Updating the blog and adding a pee");
                blog.Url = "https://devpoos.microsoft.com/dotnet";
                blog.Pee.Add(
                    new Pee { Date = "7/10", Number =  "5"});
                db.SaveChanges();
                */
                // Delete
                /*
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();
                */
            }
        }
    }
}