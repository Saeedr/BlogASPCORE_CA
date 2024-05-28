using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Commands
{
    public  class PostAddCommand:IRequest<AddPostResponse>
    {
        public string title { get; set; }
        public string Content { get; set; }
    }
    public class AddPostResponse
    {
          public int Id { get; set; }
    }
}
