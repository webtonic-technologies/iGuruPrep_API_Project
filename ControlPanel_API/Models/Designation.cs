using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPanel_API.Models
{    
    public class Designation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]      
        public int DesgnID { get; set; }
        [Required]
        public int? DesignationNumber { get; set; }
        [Required]
        public string DesignationName { get; set; }
        [Required]
        public string DesgnCode { get; set; }
        [Required]
        public bool? Status { get; set; }
    }
}
