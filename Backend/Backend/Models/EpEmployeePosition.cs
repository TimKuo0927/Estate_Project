using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

[Table("EP_employee_position")]
public partial class EpEmployeePosition
{
    [Key]
    [Column("position_id")]
    public int PositionId { get; set; }

    [Column("position_name")]
    [StringLength(50)]
    public string PositionName { get; set; } = null!;

    [InverseProperty("Position")]
    public virtual ICollection<EpEmployee> EpEmployees { get; set; } = new List<EpEmployee>();
}
