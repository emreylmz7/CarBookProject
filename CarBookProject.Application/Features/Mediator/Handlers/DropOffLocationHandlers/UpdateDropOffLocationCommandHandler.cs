using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.DropOffLocationCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.DropOffDropOffLocationHandlers
{
    public class UpdateDropOffLocationCommandHandler : IRequestHandler<UpdateDropOffLocationCommand>
    {
        private readonly IRepository<DropOffLocation> _repository;
        private readonly IMapper _mapper;

        public UpdateDropOffLocationCommandHandler(IRepository<DropOffLocation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateDropOffLocationCommand request, CancellationToken cancellationToken)
        {
            var locationEntity = await _repository.GetByIdAsync(request.DropOffLocationId);

            if (locationEntity != null)
            {
                _mapper.Map(request, locationEntity);

                await _repository.UpdateAsync(locationEntity);
            }
        }
    }
}
