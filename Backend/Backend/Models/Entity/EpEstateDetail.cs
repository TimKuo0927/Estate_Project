using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models.Entity;

[Table("EP_estate_detail")]
public partial class EpEstateDetail
{
    [Key]
    [Column("detail_id")]
    public int DetailId { get; set; }

    [Column("estate_id")]
    [StringLength(50)]
    public string EstateId { get; set; } = null!;

    [Column("detail_num_bedroom")]
    public int DetailNumBedroom { get; set; }

    [Column("detail_num_bathroom")]
    public int DetailNumBathroom { get; set; }

    [Column("detail_num_garage")]
    public int DetailNumGarage { get; set; }

    [Column("detail_latitude")]
    [StringLength(50)]
    public string DetailLatitude { get; set; } = null!;

    [Column("timestamp", TypeName = "datetime")]
    public DateTime Timestamp { get; set; }

    [Column("isDelete")]
    public bool IsDelete { get; set; }

    [ForeignKey("EstateId")]
    [InverseProperty("EpEstateDetails")]
    public virtual EpEstate Estate { get; set; } = null!;
}
