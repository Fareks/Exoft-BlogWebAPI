using Business_Logic.DTO;
using Business_Logic.Services.CommentServices;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        ICommentService _comService;
        public CommentController(ICommentService comService)
        {
            _comService = comService;
        }

        [HttpGet]
        public async Task<IEnumerable<CommentReadDTO>> GetAllById()
        {
            var comments = await _comService.GetAllAsync();
            return comments;
        }

        //[HttpGet("{id}")]
    }
}
