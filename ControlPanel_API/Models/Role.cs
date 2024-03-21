﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlPanel_API.Models
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int? RoleNumber { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string RoleCode { get; set; }
        [Required]
        public int? Status { get; set; }
    }
}
