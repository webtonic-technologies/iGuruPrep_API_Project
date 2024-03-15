using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
