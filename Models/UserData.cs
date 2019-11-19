using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MIS4200Team11.Models
{
    public class UserData
    {
        [Key]
        [Required]
        public Guid userID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display (Name = "Hire Date")]
        [DataType(DataType.Date)]
        public DateTime hireDate { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Business Units")]
        [Required]
        public int unitID { get; set; }

        public virtual BusinessUnit BusinessUnits { get; set; }
        [Display(Name ="Employee Recognized")]
        public string fullName { get { return lastName + ", " + firstName; } }
       
        public ICollection<recognition> recognitions { get; set; }
      

    }
}