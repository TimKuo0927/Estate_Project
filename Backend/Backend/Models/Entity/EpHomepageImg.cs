using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.Entity
{
    public class EpHomepageImg
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public string InsertUser { get; set; }
        public bool IsDelete { get; set; }
        public DateTime Timestamp { get; set; }

        public EpEstateImg Image { get; set; } = null!;
        public EpEmployee Employee { get; set; } = null!;
    }
}
