using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Entities
{
  public  class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        //public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public string MoreDetails { get; set; }
        public string Register { get; set; }
        

    }
}
