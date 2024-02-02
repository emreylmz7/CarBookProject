using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBookProject.Application.Features.Mediator.Results.TestimonialResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialsQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly IMapper _mapper;

        public GetTestimonialsQueryHandler(IRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var testimonialEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetTestimonialQueryResult>>(testimonialEntities);

            return results;
        }
    }
}
