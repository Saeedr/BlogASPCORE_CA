using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.ObjectiveC;

namespace Blog.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult CustomOk(object data, string message = "")
        {
            return Ok(new Result()
            {
                Message=message,
                Data=data,
                Status= Status.Success
            });
        }

        public ActionResult CustomError( string message = "",object data=null)
        {
            return BadRequest(new Result()
            {
                Message = message,
                Data = data,
                Status = Status.Success
            });
        }
    }
}

public class Result
{
    public object Data { get; set; }
    public string Message { get; set; }
    public Status Status { get; set; }

}
public enum Status
{
    Success=1,
    Failed=-1
}
