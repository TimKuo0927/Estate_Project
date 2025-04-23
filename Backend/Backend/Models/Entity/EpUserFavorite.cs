using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models.Entity;

[Table("EP_user_favorite")]
public partial class EpUserFavorite
{
    [Key]
    [Column("favorite_id")]
    public int FavoriteId { get; set; }

    [Column("userid")]
    public int? Userid { get; set; }

    [Column("estate_id")]
    [StringLength(50)]
    public string? EstateId { get; set; }

    [Column("timestamp", TypeName = "datetime")]
    public DateTime? Timestamp { get; set; }

    [ForeignKey("EstateId")]
    [InverseProperty("EpUserFavorites")]
    public virtual EpEstate? Estate { get; set; }

    [ForeignKey("Userid")]
    [InverseProperty("EpUserFavorites")]
    public virtual EpUser? User { get; set; }
}
