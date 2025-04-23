using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Model
{
    public class EstateImg
    {
        public int? ImgId { get; set; }

        public string EstateId { get; set; } = null!;

        public string ImgUrl { get; set; } = null!;

        public DateTime Timestamp { get; set; }

        public bool IsDelete { get; set; }
    }
}
