using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Quaries.AboutQueries;
using CarBookProject.Application.Features.CQRS.Results.AboutResults;
using CarBookProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResult
            {
                AboutId = values.AboutId,
                Title = values.Title,
                Description = values.Description,
                ImageUrl = values.ImageUrl
            };
        }
    }
}
