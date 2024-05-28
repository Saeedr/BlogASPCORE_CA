using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int PostId { get; set; }
        public Post post { get; set; }

    }
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Content).HasMaxLength(1000);
            builder.HasOne(e => e.post).WithMany(c => c.Comments);
        }
    }
}