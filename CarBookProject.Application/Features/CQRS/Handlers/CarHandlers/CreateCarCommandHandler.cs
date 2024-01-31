using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.CarCommands;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IMapper _mapper;

        public CreateCarCommandHandler(IRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCarCommand command)
        {
 
            var carEntity = _mapper.Map<Car>(command);
            await _repository.CreateAsync(carEntity);
        }
    }
}
