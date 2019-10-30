using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MIS4200Team11.Models
{
    public class myRecognition
    {
        public int myRecognitionID { get; set; }

        [Display(Name = "Subject")]
        public string recognitionTitle { get; set; }

        [Display(Name = "What did he/she do that represented one of our values?")]
        public string recognitionDescription { get; set; }
        [DataType(DataType.Date)]
        public DateTime recognitionDate { get; set; }

        public int userID { get; set; }
        public virtual UserData UserData { get; set; }
        public int recognitionID { get; set; }
        public virtual recognition Recognition { get; set; }
    }
}