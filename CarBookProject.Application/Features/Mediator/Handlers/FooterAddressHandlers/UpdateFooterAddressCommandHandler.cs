using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;
        private readonly IMapper _mapper;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddressEntity = await _repository.GetByIdAsync(request.FooterAddressId);

            if (footerAddressEntity != null)
            {
                _mapper.Map(request, footerAddressEntity);

                await _repository.UpdateAsync(footerAddressEntity);
            }
        }
    }
}
