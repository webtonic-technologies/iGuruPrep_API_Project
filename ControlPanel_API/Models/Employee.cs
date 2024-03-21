using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ControlPanel_API.Models
{
    [Table("tblEmployee")]
    public class Employee
    {
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PinCode { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Role { get; set; }
        public string Designation { get; set; }
        public string Subjects { get; set; }
    }
}
