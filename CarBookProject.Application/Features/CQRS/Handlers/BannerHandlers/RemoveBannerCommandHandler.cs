using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProject.Application.Interfaces;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBannerCommand command)
        {
            var bannerEntity = await _repository.GetByIdAsync(command.Id);

            if (bannerEntity != null)
            {
                await _repository.DeleteAsync(bannerEntity);
            }
        }
    }
}
