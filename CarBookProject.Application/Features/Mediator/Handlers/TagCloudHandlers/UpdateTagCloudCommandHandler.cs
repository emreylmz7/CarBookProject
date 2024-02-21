using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.TagCloudCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;
        private readonly IMapper _mapper;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var tagCloudEntity = await _repository.GetByIdAsync(request.TagCloudId);

            if (tagCloudEntity != null)
            {
                _mapper.Map(request, tagCloudEntity);

                await _repository.UpdateAsync(tagCloudEntity);
            }
        }
    }
}
