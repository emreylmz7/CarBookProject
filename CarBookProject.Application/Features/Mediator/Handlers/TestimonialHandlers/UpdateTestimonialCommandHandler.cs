using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly IMapper _mapper;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonialEntity = await _repository.GetByIdAsync(request.TestimonialId);

            if (testimonialEntity != null)
            {
                _mapper.Map(request, testimonialEntity);

                await _repository.UpdateAsync(testimonialEntity);
            }
        }
    }
}
