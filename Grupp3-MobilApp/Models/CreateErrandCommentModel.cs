using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp3_MobilApp.Models
{
    public class CreateErrandCommentModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid Author { get; set; }
        public DateTime PostedAt { get; set; }
        public Guid ErrandId { get; set; }
    }
}
