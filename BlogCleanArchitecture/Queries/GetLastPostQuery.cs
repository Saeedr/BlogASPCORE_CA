using BlogCleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Blog.Core.Queries
{
    public class GetLastPostQuery:IRequest<List<Post>>
    {
    }
}
