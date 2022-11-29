using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp3_MobilApp.Models
{
    public class ChangeErrandStatusModel
    {
        public string ErrandId { get; set; }
        public string Status { get; set; }
        public string LastEdited { get; set; } 
    }
}
