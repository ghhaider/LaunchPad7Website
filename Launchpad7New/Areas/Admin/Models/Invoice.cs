using Launchpad.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Launchpad7New.Areas.Admin.Models
{
    public class Invoice
    {
        public Invoice()
        {
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
         [Required]
        public int UserId { get; set; }
        [Required]
        public int InvoiceNumber { get; set; }
         [Required]
        public int PaymentMethod { get; set; }
        [Required]
        [DisplayName("Select Package")]
        public int PackageId { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        [Required]
        [DisplayName("No. of Members")]
        public int Members { get; set; }
        [DisplayName("Total")]
        public int TotalPrice { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? IssueDate { get; set; }

        [Required]
        public int Status { get; set; }
        [Required]
        public string Comments { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        [DisplayName("Confirm Payment Date")]
        public DateTime? PaymentDate { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}