using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ServiceCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ServiceHandlers 
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand> 
    {
        private readonly IRepository<Service> _repository; 
        private readonly IMapper _mapper;

        public CreateServiceCommandHandler(IRepository<Service> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceEntity = _mapper.Map<Service>(request); 
            await _repository.CreateAsync(serviceEntity); 
        }
    }
}
