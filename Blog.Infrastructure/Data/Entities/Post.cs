using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Data.Entities
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
        public IEnumerable<PostTag> PostTags { get; set; }


    }

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
       public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Postes");
            builder.HasKey(x => x.Id);  
            builder.Property(p=>p.Title).HasMaxLength(50);
            builder.Property(p=>p.Content).HasMaxLength(1000);
        }
    }
}
