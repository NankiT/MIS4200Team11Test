using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MIS4200Team11.Models
{
    public class BusinessUnit
    {
        [Key]
        [Required]
        public int unitID { get; set; }

        [Required]
        public string businessUnit { get; set; }
        public ICollection<UserData> UserData { get; set; }
    }
}