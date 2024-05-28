
using Blog.Core.Commands;
using BlogCleanArchitecture.Domain;
using BlogCleanArchitecture.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Data.Repository
{
    public class PostRepository : IPostRepository
    {
        public BlogDbContext Context { get;  }
        public PostRepository(BlogDbContext blogDbContext) 
        {
            Context=blogDbContext;
        }
        public async Task<List<Post>> GetLatesPost(int Count)
        {
         return await Context.Posts.Select(x=>new Post{Id=x.Id,Title=x.Title,Content=x.Content,CreateDate=x.CreateDate }).OrderByDescending(x=>x.CreateDate).Take(Count).ToListAsync();
        }

        public async Task<int> Add(PostAddCommand post)
        {
            var dbmodel = new Blog.Infrastructure.Data.Entities.Post
            {
                CreateDate = DateTime.Now,
                Title = post.title,
               Content = post.Content
            };
            Context.Posts.Add(dbmodel);
            Context.SaveChanges();
            return dbmodel.Id;
        }
    }
}
