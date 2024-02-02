using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.LocationCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.LocationHandlers 
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand> 
    {
        private readonly IRepository<Location> _repository;
        private readonly IMapper _mapper;

        public CreateLocationCommandHandler(IRepository<Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var locationEntity = _mapper.Map<Location>(request);
            await _repository.CreateAsync(locationEntity);
        }
    }
}
