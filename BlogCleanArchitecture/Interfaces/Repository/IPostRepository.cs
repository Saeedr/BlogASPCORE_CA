using Blog.Core.Commands;
using BlogCleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCleanArchitecture.Interfaces.Repository
{
    public interface IPostRepository
    {
       Task<List<Post>> GetLatesPost(int Count);
        Task<int> Add(PostAddCommand post);
    }
}
