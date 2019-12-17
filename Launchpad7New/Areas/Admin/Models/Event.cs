using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Launchpad7New.Areas.Admin.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Location { get; set; }
        [Required]
        //[DataType(DataType.Date)]
        //public string Description { get; set; }
        public System.DateTime Date { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Time { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string MoreDetails { get; set; }
        [Required]
        public string Register { get; set; }
    }
}