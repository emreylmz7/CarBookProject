using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands; 
using CarBookProject.Application.Features.Mediator.Results.ReviewResults; 

namespace CarBookProject.WebApi.Mappings
{
	public class ReviewProfile : Profile 
	{
		public ReviewProfile()
		{
			CreateMap<Review, CreateReviewCommand>().ReverseMap();
			CreateMap<RemoveReviewCommand, Review>().ReverseMap(); 
			CreateMap<UpdateReviewCommand, Review>().ReverseMap(); 

			CreateMap<Review, GetReviewQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser!.Name + " "+ src.AppUser.Surname))
                .ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.AppUser!.ProfilePicture))
				.ReverseMap(); 
			CreateMap<Review, GetReviewByIdQueryResult>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser!.Name + " " + src.AppUser.Surname))
				.ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.AppUser!.ProfilePicture))
				.ReverseMap();
			CreateMap<Review, GetReviewByCarIdQueryResult>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser!.Name + " " + src.AppUser.Surname))
				.ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.AppUser!.ProfilePicture))
				.ReverseMap();
		}
	}
}
