using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly SolventContext e_context;
        public BuggyController(SolventContext context)
        {
            e_context = context;

        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = e_context.Banks.Find(34);
            if(thing == null)
            {
                return NotFound( new ApiResponse(404));
            }
            return Ok();
        }
         [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
              var thing = e_context.Banks.Find(34);
              var thingreturnnull =thing.ToString();
           
            return Ok();
        }
         [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}