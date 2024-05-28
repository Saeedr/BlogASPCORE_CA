using Blog.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Data
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet <Category> Categories { get; set; }
        public BlogDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagConfiguration());

        }
    }
    public class BloggingContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            optionBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=BlogSample;Integrated Security=False;User ID=sa;Password=tirage@1394;Connect Timeout=30;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;Integrated Security=False;");
            return new BlogDbContext(optionBuilder.Options);
        }
    }
}
