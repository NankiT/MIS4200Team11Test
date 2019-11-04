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
        public int unitID { get; set; }
        public virtual BusinessUnit BusinessUnits { get; set; }
        public string fullName { get { return lastName + ", " + firstName; } }
       
        public ICollection<recognition> recognitions { get; set; }
        public ICollection<myRecognition> myRecognitions { get; set; }
      

    }
}