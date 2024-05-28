using Blog.Core.Commands;
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
    public class AddPostHandler : IRequestHandler<PostAddCommand, AddPostResponse>
    {
        public IPostRepository PostRepository { get; }
        public AddPostHandler(IPostRepository postRepository)
        {
            PostRepository = postRepository;
        }
      

      

        public async Task<AddPostResponse> Handle(PostAddCommand request, CancellationToken cancellationToken)
        {
            return new AddPostResponse { Id = await PostRepository.Add(request) };

        }
    }
}
