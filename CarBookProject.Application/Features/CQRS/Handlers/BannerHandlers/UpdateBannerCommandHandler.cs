using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProject.Application.Interfaces;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public UpdateBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var bannerEntity = await _repository.GetByIdAsync(command.BannerId);
            _mapper.Map(command, bannerEntity);

            await _repository.UpdateAsync(bannerEntity);
        }
    }
}
