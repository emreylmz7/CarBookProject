using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProject.Application.Interfaces;
using AutoMapper;

namespace CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public CreateBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateBannerCommand command)
        {
            var bannerEntity = _mapper.Map<Banner>(command);

            await _repository.CreateAsync(bannerEntity);
        }
    }
}
