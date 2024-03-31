using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.CommentCommands
{
    public class CreateCommentCommand : IRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
