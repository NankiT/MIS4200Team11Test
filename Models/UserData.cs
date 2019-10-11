﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MIS4200Team11.Models
{
    public class UserData
    {
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
        public ICollection<BusinessUnit> businessUnits { get; set; }

    }
}