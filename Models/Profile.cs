using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Team11.Models
{
    public class Profile
    {
        [Key]
        [Required]
        [Display(Name = "Employee ID")]
        public int employeeID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Hire Date")]
        [DataType(DataType.DateTime)]
        public DateTime hireDate { get; set; }
    }
}