using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBookProject.Application.Features.Mediator.Results.TestimonialResults;

namespace CarBookProject.WebApi.Mappings
{
    public class TestimonialProfile : Profile
    {
        public TestimonialProfile()
        {
            CreateMap<CreateTestimonialCommand, Testimonial>().ReverseMap();
            CreateMap<RemoveTestimonialCommand, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialCommand, Testimonial>().ReverseMap();
            CreateMap<GetTestimonialByIdQueryResult, Testimonial>().ReverseMap();
            CreateMap<GetTestimonialQueryResult, Testimonial>().ReverseMap();
        }
    }
}
