﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuiTienQuat_SE1814_NET_PT2.Models;

public partial class Student
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 3);

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Date of Birth is required")]
    public DateTime? Dob { get; set; }

    [Required(ErrorMessage = "Major is required")]
    [MaxLength(100)]
    public string? Major { get; set; }
}
