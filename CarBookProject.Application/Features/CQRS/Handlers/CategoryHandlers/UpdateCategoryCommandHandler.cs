using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookProject.Application.Interfaces;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var categoryEntity = await _repository.GetByIdAsync(command.CategoryId);

            if (categoryEntity != null)
            {
                _mapper.Map(command, categoryEntity);

                await _repository.UpdateAsync(categoryEntity);
            }
        }
    }
}
