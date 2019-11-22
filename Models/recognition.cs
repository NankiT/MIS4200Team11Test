using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Team11.Models
{
    public class recognition
    {
        [Key]
        public Guid recognitionID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string recognitionTitle { get; set; }

        [Required]
        [Display(Name = "What did they do that represented one of our values?")]
        public string recognitionDescription { get; set; }

        [Required]
        [Display(Name = "Date of Recognition")]
        [DataType(DataType.Date)]
        public DateTime recognitionDate { get; set; }

        //linking the user data
        [Required]
        [Display(Name ="User Being Recognized")]
        public Guid userID { get; set; }
        
        public virtual UserData UserData { get; set; }

        //linking the core values
        [Required]
        [Display(Name ="Core Value")]
        public int valueId { get; set; }
        
        public virtual CoreValues CoreValues { get; set; }

        
    }
}