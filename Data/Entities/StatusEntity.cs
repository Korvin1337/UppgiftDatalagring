﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities;

public class StatusEntity
{
    [Key]
    public int StatusId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string StatusName { get; set; } = null!;

}
