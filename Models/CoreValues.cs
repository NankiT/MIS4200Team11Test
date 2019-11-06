﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MIS4200Team11.Models
{
    public class CoreValues
    {
        [Key]
        [Required]
        public int valueId { get; set; }

        [Required]
        public string valueName { get; set; }

        [Required]
        public string valueDescription { get; set; }

        public ICollection<recognition> recognitions { get; set; }

        //public ICollection<UserData> UserData { get; set; }

    }
}