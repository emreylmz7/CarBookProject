using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.AboutCommands;
using CarBookProject.Application.Interfaces;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public CreateAboutCommandHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAboutCommand command)
        {
            var aboutEntity = _mapper.Map<About>(command);

            await _repository.CreateAsync(aboutEntity);
        }
    }
}
