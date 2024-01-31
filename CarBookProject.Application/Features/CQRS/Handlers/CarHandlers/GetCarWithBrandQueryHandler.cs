using AutoMapper;
using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces.CarInterfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public GetCarWithBrandQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _repository.GetCarsWithBrands();
            var results = _mapper.Map<List<GetCarWithBrandQueryResult>>(values);
            return results;

            //return values.Select(x => new GetCarWithBrandQueryResult
            //{
            //    BrandName = x.Brand.Name,
            //});

        }
    }
}
