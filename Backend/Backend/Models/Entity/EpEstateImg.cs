using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models.Entity;

[Table("EP_estate_img")]
public partial class EpEstateImg
{
    [Key]
    [Column("img_id")]
    public int ImgId { get; set; }

    [Column("estate_id")]
    [StringLength(50)]
    public string EstateId { get; set; } = null!;

    [Column("img_url")]
    [StringLength(100)]
    public string ImgUrl { get; set; } = null!;

    [Column("timestamp", TypeName = "datetime")]
    public DateTime Timestamp { get; set; }

    [Column("isDelete")]
    public bool IsDelete { get; set; }

    [ForeignKey("EstateId")]
    [InverseProperty("EpEstateImgs")]
    public virtual EpEstate Estate { get; set; } = null!;
}
