using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.BrandCommands;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateBrandCommand command)
        {
            // Use AutoMapper to map properties from CreateBrandCommand to Brand
            var brandEntity = _mapper.Map<Brand>(command);

            await _repository.CreateAsync(brandEntity);
        }
    }
}
