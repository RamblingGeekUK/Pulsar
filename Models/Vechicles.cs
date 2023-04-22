using System.ComponentModel.DataAnnotations;

namespace Pulsar.Models
{
    public class Vechicles
    {
        [DataType(DataType.Date)]
        public DateTime dateTime { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; } = string.Empty;
        public int Speed { get; set; } = 0; // out of 10
        public int SpeedTime { get; set; } = 0;
        public int NumberOfBoost { get; set; } = 0; // out of 10
        public int OverallRating { get; set; } = 0; // out of 10

        // How rare vehicle is, 1 - 6, 1 = worst, 6 = best // Pulsar Unlimited = 6, unlimited = 5, gold = 4, orange = 3, red = 2, pruple = 1
        public int Rarity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
