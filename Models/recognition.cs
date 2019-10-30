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
        [Display(Name = "What did he/she do that represented one of our values?")]
        public string recognitionDescription { get; set; }

        [Display(Name = "Date of Recognition")]
        [DataType(DataType.Date)]
        public DateTime recognitionDate { get; set; }

        //linking the user data
        public Guid userID { get; set; }
        public virtual UserData UserData { get; set; }

        //linking the core values
        public int valueId { get; set; }
        public virtual CoreValues CoreValues { get; set; }

        
    }
}