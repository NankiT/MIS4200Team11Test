﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Team11.Models
{
    public class recognition
    {
        public int recognitionID { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string recognitionTitle { get; set; }

        [Required]
        [Display(Name = "What did he/she do that represented one of our values?")]
        public string recognitionDescription { get; set; }

        [Display(Name = "Date of Recognition")]
        [DataType(DataType.Date)]
        public DateTime recognitionDate { get; set; }
    }
}