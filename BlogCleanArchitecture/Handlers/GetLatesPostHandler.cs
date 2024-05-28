using Blog.Core.Queries;
using BlogCleanArchitecture.Domain;
using BlogCleanArchitecture.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Handlers
{
    public class GetLatesPostHandler : IRequestHandler<GetLastPostQuery, List<Post>>
    {
        public IPostRepository PostRepository { get;  }
        public GetLatesPostHandler(IPostRepository postRepository)
        {
            PostRepository = postRepository;
        }
        public async Task<List<Post>> Handle(GetLastPostQuery request, CancellationToken cancellationToken)
        {
          return await  PostRepository.GetLatesPost(20);
        }
    }
}
