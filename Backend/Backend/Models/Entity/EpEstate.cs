using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models.Entity;

[Table("EP_estate")]
public partial class EpEstate
{
    [Key]
    [Column("estate_id")]
    [StringLength(50)]
    public string EstateId { get; set; } = null!;

    [Column("estate_address")]
    [StringLength(50)]
    public string EstateAddress { get; set; } = null!;

    [Column("estate_city")]
    [StringLength(50)]
    public string EstateCity { get; set; } = null!;

    [Column("estate_state")]
    [StringLength(50)]
    public string EstateState { get; set; } = null!;

    [Column("estate_zip")]
    [StringLength(50)]
    public string EstateZip { get; set; } = null!;

    [Column("estate_price", TypeName = "money")]
    public decimal EstatePrice { get; set; }

    [Column("estate_description")]
    public string EstateDescription { get; set; } = null!;

    [Column("estate_age")]
    [StringLength(20)]
    public string? EstateAge { get; set; }

    [Column("estate_type")]
    [StringLength(50)]
    public string EstateType { get; set; } = null!;

    [Column("estate_annualTax", TypeName = "money")]
    public decimal EstateAnnualTax { get; set; }

    [Column("estate_size_sqft")]
    public int EstateSizeSqft { get; set; }

    [Column("timestamp", TypeName = "datetime")]
    public DateTime Timestamp { get; set; }

    [Column("employee_id")]
    [StringLength(50)]
    public string EmployeeId { get; set; } = null!;

    [Column("isDelete")]
    public bool? IsDelete { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("EpEstates")]
    public virtual EpEmployee Employee { get; set; } = null!;

    [InverseProperty("Estate")]
    public virtual ICollection<EpEstateDetail> EpEstateDetails { get; set; } = new List<EpEstateDetail>();

    [InverseProperty("Estate")]
    public virtual ICollection<EpEstateImg> EpEstateImgs { get; set; } = new List<EpEstateImg>();

    [InverseProperty("Estate")]
    public virtual ICollection<EpUserFavorite> EpUserFavorites { get; set; } = new List<EpUserFavorite>();
}
