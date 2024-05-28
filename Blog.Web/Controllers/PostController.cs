using Blog.Core.Commands;
using Blog.Core.Queries;
using Blog.Core.ViewModels;
using Blog.Infrastructure.Data.Repository;
using BlogCleanArchitecture.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : BaseController
    {
       
        public IMediator mediator { get; set; }
        public PostController(IMediator mediator)
        {
           this.mediator = mediator;
        }
      //  /post/getLatesPosts
        [HttpGet("GetLatesPosts")]
        public async Task<IActionResult> GetLatesPost()
        {
            var query =new  GetLastPostQuery();
            var resul=mediator.Send(query);
            return CustomOk(resul);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostAddVm postAddVm)
        {
            var Command = new PostAddCommand
            {
                Content = postAddVm.Content,
                title = postAddVm.Title
            };
            var resul = mediator.Send(Command);
            return CustomOk(resul);
        }


    }
}
