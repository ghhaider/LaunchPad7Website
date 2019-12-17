using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Launchpad7New.Areas.Admin.Models
{
    public class NewsLetter
    {
        public NewsLetter() { CreatedDate = DateTime.Now; }

        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}