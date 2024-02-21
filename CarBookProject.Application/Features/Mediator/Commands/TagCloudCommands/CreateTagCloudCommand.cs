using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class CreateTagCloudCommand : IRequest
    {
        public string? Title { get; set; }
        public int BlogId { get; set; }
    }
}
