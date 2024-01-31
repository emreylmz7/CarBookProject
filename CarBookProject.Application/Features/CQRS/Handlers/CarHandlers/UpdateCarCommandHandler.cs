using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.CarCommands;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IMapper _mapper;

        public UpdateCarCommandHandler(IRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var carEntity = await _repository.GetByIdAsync(command.CarId);

            if (carEntity != null)
            {
                _mapper.Map(command, carEntity);

                await _repository.UpdateAsync(carEntity);
            }
        }
    }
}
