using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.BrandCommands;
using CarBookProject.Application.Interfaces;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBrandCommand command)
        {
            var brandEntity = await _repository.GetByIdAsync(command.BrandId);

            if (brandEntity != null)
            {
                _mapper.Map(command, brandEntity);

                await _repository.UpdateAsync(brandEntity);
            }
        }
    }
}
