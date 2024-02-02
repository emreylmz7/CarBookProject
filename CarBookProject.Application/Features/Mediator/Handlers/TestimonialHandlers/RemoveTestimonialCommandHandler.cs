using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonialEntity = await _repository.GetByIdAsync(request.Id);

            if (testimonialEntity != null)
            {
                await _repository.DeleteAsync(testimonialEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
