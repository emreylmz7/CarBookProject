using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.DropOffLocationCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.DropOffLocationHandlers
{
    public class CreateDropOffLocationCommandHandler : IRequestHandler<CreateDropOffLocationCommand>
    {
        private readonly IRepository<DropOffLocation> _repository;
        private readonly IMapper _mapper;

        public CreateDropOffLocationCommandHandler(IRepository<DropOffLocation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateDropOffLocationCommand request, CancellationToken cancellationToken)
        {
            var dropOffLocationEntity = _mapper.Map<DropOffLocation>(request);
            await _repository.CreateAsync(dropOffLocationEntity);
        }
    }
}
