using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Backend.Models.Entity;

namespace Backend.Models.Model
{
    public class Estate
    {
        public string? EstateId { get; set; }

        public string EstateAddress { get; set; } = null!;

        public string EstateCity { get; set; } = null!;

        public string EstateState { get; set; } = null!;

        public string EstateZip { get; set; } = null!;

        public decimal EstatePrice { get; set; }

        public string EstateDescription { get; set; } = null!;
        public string? EstateAge { get; set; }

        public string EstateType { get; set; } = null!;

        public decimal EstateAnnualTax { get; set; }

        public int EstateSizeSqft { get; set; }

        public DateTime Timestamp { get; set; }

        public string EmployeeId { get; set; } = null!;

        public bool? IsDelete { get; set; }

        public List<EpEstateImg>? estateImgList { get; set; }
        public EstateDetail estateDetail { get; set; }

    }
}
