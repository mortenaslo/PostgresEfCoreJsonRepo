using System;
using System.Text.Json;
using System.Threading.Tasks;

using EfCoreJsonRepo.Data;

using Microsoft.EntityFrameworkCore;

namespace EfCoreJsonRepo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var dbContext = new NiceDbContext();
            await dbContext.Database.MigrateAsync();
            if (!await dbContext.People.AnyAsync() && !await dbContext.Cars.AnyAsync())
            {
                dbContext.People.AddRange(new Models.Person[]
                {
                    new Models.Person()
                    {
                        Name = "John Doe",
                        Document = JsonDocument.Parse("{\"Title\":\"Senior\"}")
                    }
                });
                dbContext.Cars.AddRange(new Models.Car[]
                {
                    new Models.Car()
                    {
                        Model = "Skoda",
                        Document = JsonDocument.Parse("{\"HP\":94}")
                    }
                });
                await dbContext.SaveChangesAsync();
            }

            var cars = await dbContext.Cars.ToListAsync();
            var people = await dbContext.People.ToListAsync();
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}: \n - {car.Document.RootElement.GetRawText()}");
            }
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}: \n - {person.Document.RootElement.GetRawText()}");
            }
        }
    }
}
