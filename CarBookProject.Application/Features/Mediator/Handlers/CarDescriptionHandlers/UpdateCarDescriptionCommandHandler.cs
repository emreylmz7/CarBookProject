using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.CarDescriptionCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class UpdateCarDescriptionCommandHandler : IRequestHandler<UpdateCarDescriptionCommand>
    {
        private readonly IRepository<CarDescription> _repository;
        private readonly IMapper _mapper;

        public UpdateCarDescriptionCommandHandler(IRepository<CarDescription> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var carDescription = await _repository.GetByIdAsync(request.CarDescriptionId);

            if (carDescription != null)
            {
                _mapper.Map(request, carDescription);
                await _repository.UpdateAsync(carDescription);
            }
            else
            {
                // Handle the case where the car description is not found (e.g., log a warning)
                // ...
            }
        }
    }
}
