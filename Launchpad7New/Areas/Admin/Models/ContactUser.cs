using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Launchpad7New.Areas.Admin.Models
{
    public class ContactUser
    {

        public int Id { get; set; }

        public string Name { get; set; }
       

        public string Email { get; set; }
        

        public int Phone { get; set; }

        public string Message { get; set; }
    
     




    }
}