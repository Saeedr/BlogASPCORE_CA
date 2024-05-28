using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCleanArchitecture.Domain
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int CommentId { get; set; }
        public IEnumerable<Comment> Comments { get; set; }


    }
}
