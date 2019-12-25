using System.Text.Json;

namespace EfCoreJsonRepo.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public JsonDocument Document { get; set; }
    }
}
