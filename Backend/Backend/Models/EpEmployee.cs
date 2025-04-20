using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

[Table("EP_employee")]
[Index("EmployeeEmail", Name = "UQ__EP_emplo__0A874BCFB0C4403D", IsUnique = true)]
public partial class EpEmployee
{
    [Key]
    [Column("employee_id")]
    [StringLength(50)]
    public string EmployeeId { get; set; } = null!;

    [Column("employee_full_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string EmployeeFullName { get; set; } = null!;

    [Column("employee_email")]
    [StringLength(100)]
    [Unicode(false)]
    public string EmployeeEmail { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(255)]
    [Unicode(false)]
    public string PasswordHash { get; set; } = null!;

    [Column("employee_phone")]
    [StringLength(20)]
    [Unicode(false)]
    public string? EmployeePhone { get; set; }

    [Column("position_id")]
    public int? PositionId { get; set; }

    [Column("last_login", TypeName = "datetime")]
    public DateTime LastLogin { get; set; }

    [Column("isDelete")]
    public bool IsDelete { get; set; }

    [Column("timestamp", TypeName = "datetime")]
    public DateTime? Timestamp { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<EpEstate> EpEstates { get; set; } = new List<EpEstate>();

    [ForeignKey("PositionId")]
    [InverseProperty("EpEmployees")]
    public virtual EpEmployeePositionId? Position { get; set; }
}
