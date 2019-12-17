using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Entities
{
  public  class Invoice
    {
      public Invoice()
      {
          CreatedDate = DateTime.Now;
      }
      public int Id { get; set; }
      public int UserId { get; set; }
      public int InvoiceNumber { get; set; }
      public int PaymentMethod { get; set; }
      public int PackageId { get; set; }
      public virtual ICollection<Package> Packages { get; set; }
      public int Members { get; set; }
      public int TotalPrice { get; set; }
      public DateTime? IssueDate { get; set; }
      public int Status { get; set; }
      public string Comments { get; set; }
      public DateTime? UpdatedDate { get; set; }
      public int? UpdatedBy { get; set; }
      public DateTime? PaymentDate { get; set; }
      public string CreatedById { get; set; }
      public DateTime CreatedDate { get; set; }
    }
}
