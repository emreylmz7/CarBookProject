using CarBookProject.Application.Features.Mediator.Commands.CommentCommands;
using CarBookProject.Application.Features.Mediator.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _mediator.Send(new GetCommentQuery());
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _mediator.Send(new GetCommentByIdQuery(id)); 
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command) 
        {
            await _mediator.Send(command);
            return Ok("Comment added successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id) 
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return Ok("Comment removed successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, UpdateCommentCommand command) 
        {
            command.CommentId = id; 
            await _mediator.Send(command);
            return Ok("Comment updated successfully");
        }

        [HttpGet("GetCommentsByBlogId")]
        public async Task<IActionResult> GetCommentsByBlogId(int id)
        {
            var comment = await _mediator.Send(new GetCommentsByBlogQuery(id));
            return Ok(comment);
        }
    }
}
