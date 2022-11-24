using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp3_MobilApp.Models
{
    public class ErrandCommentModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid? Author { get; set; }
        public DateTime PostedAt { get; set; }

        public ErrandCommentModel(Guid id, string content, string author, DateTime postedAt)
        {
            Id = id;
            Content = content;
            if (Guid.TryParse(author, out Guid authorGuid))
                Author = authorGuid;
            else
                Author = null;
            PostedAt = postedAt;
        }
    }
}
