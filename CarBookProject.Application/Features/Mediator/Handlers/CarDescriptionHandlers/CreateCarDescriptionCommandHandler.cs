using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.CarDescriptionCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class CreateCarDescriptionCommandHandler : IRequestHandler<CreateCarDescriptionCommand>
    {
        private readonly IRepository<CarDescription> _repository;
        private readonly IMapper _mapper;

        public CreateCarDescriptionCommandHandler(IRepository<CarDescription> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var carDescriptionEntity = _mapper.Map<CarDescription>(request);
            await _repository.CreateAsync(carDescriptionEntity);
        }
    }
}
