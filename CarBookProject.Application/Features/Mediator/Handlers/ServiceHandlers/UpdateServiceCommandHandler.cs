using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ServiceCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ServiceHandlers 
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand> 
    {
        private readonly IRepository<Service> _repository; 
        private readonly IMapper _mapper;

        public UpdateServiceCommandHandler(IRepository<Service> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceEntity = await _repository.GetByIdAsync(request.ServiceId); 

            if (serviceEntity != null)
            {
                _mapper.Map(request, serviceEntity); 

                await _repository.UpdateAsync(serviceEntity);
            }
        }
    }
}
