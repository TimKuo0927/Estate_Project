using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

[Table("EP_user")]
[Index("UserEmail", Name = "UQ__EP_user__B0FBA212F7090C17", IsUnique = true)]
public partial class EpUser
{
    [Key]
    [Column("userid")]
    public int Userid { get; set; }

    [Column("user_full_name")]
    [StringLength(100)]
    public string UserFullName { get; set; } = null!;

    [Column("user_prefer_name")]
    [StringLength(50)]
    public string? UserPreferName { get; set; }

    [Column("user_email")]
    [StringLength(100)]
    public string UserEmail { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [Column("user_phone")]
    [StringLength(20)]
    public string? UserPhone { get; set; }

    [Column("timestamp", TypeName = "datetime")]
    public DateTime? Timestamp { get; set; }

    [Column("isDelete")]
    public bool IsDelete { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<EpUserFavorite> EpUserFavorites { get; set; } = new List<EpUserFavorite>();
}
