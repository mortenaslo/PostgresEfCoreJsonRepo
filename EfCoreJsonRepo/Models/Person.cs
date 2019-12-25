using System.Text.Json;

namespace EfCoreJsonRepo.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public JsonDocument Document { get; set; }
    }
}
