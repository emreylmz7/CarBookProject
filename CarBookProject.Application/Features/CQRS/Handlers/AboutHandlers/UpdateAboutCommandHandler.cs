using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.AboutCommands;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public UpdateAboutCommandHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAboutCommand command)
        {
            var aboutEntity = await _repository.GetByIdAsync(command.AboutId);
            _mapper.Map(command, aboutEntity);

            await _repository.UpdateAsync(aboutEntity);
        }
    }
}
