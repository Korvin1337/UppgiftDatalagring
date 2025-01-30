﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities;

/* Chatgpt help me with the syntax for datetime and foregin keys */

public class ProjectEntity
{
    [Key]
    public int ProjectId { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string ProjectName { get; set; } = null!;
    
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime StartDate { get; set; }
    
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime EndDate { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string ProjectManager { get; set; } = null!;
    
    [Required]
    [ForeignKey(nameof(Customer))] /* Generated by chatgpt 4o, using the foreign key to link to customer */
    public int CustomerId { get; set; }
    
    [Required]
    public decimal TotalCost { get; set; } /*, chatgpt4o generated/suggested decimal instead of int */

    [Required]
    [ForeignKey(nameof(StatusEntity))]
    public int StatusId { get; set; }

    /* Generated by chatgpt 4o, navigation for the property customer */
    /* Make Virtual If Lazy Loading */
    public virtual CustomerEntity Customer { get; set; } = null!;
    public virtual StatusEntity StatusEntity { get; set; } = null!;
}
