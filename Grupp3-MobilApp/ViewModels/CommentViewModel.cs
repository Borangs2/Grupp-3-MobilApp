using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupp3_MobilApp.Models;

namespace Grupp3_MobilApp.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public TechnicianModel Author { get; set; }
        public DateTime PostedAt { get; set; }
    }
}
