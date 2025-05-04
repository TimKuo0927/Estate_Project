using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Model
{
    public class EstateDetail
    {
        public int DetailId { get; set; }

        public string? EstateId { get; set; }

        public int DetailNumBedroom { get; set; }

        public int DetailNumBathroom { get; set; }

        public int DetailNumGarage { get; set; }

        public string DetailLatitude { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsDelete { get; set; }
    }
}
