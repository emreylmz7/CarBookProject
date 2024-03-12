using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBookProject.Application.Features.Mediator.Results.StatisticsResults;
using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.StatisticsHandler
{
    public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, GetStatisticsQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetStatisticsQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetStatisticsQueryResult> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
        {
            var statistics = new GetStatisticsQueryResult
            {
                TotalCarCount = await Task.Run(() => _repository.GetTotalCarCount()),
                TotalLocationCount = await Task.Run(() => _repository.GetTotalLocationCount()),
                TotalAuthorCount = await Task.Run(() => _repository.GetTotalAuthorCount()),
                TotalBlogCount = await Task.Run(() => _repository.GetTotalBlogCount()),
                TotalBrandCount = await Task.Run(() => _repository.GetTotalBrandCount()),
                AverageHourlyRentPrice = await Task.Run(() => _repository.GetAverageHourlyRentPrice()),
                AverageDailyRentPrice = await Task.Run(() => _repository.GetAverageDailyRentPrice()),
                AverageWeeklyRentPrice = await Task.Run(() => _repository.GetAverageWeeklyRentPrice()),
                AverageMonthlyRentPrice = await Task.Run(() => _repository.GetAverageMonthlyRentPrice()),
                AutomaticTransmissionCarCount = await Task.Run(() => _repository.GetAutomaticTransmissionCarCount()),
                BrandWithMostCars = await Task.Run(() => _repository.GetBrandWithMostCars()),
                BlogWithMostComments = await Task.Run(() => _repository.GetBlogWithMostComments()),
                CarCountByKmSmallerThan1000 = await Task.Run(() => _repository.GetCarCountByKmSmallerThan1000()),
                CarCountWithPriceLessThan1000 = await Task.Run(() => _repository.GetCarCountWithPriceLessThan1000()),
                GasolineOrDieselCarCount = await Task.Run(() => _repository.GetGasolineOrDieselCarCount()),
                ElectricCarCount = await Task.Run(() => _repository.GetElectricCarCount()),
                CarBrandAndModelWithHighestDailyRentPrice = await Task.Run(() => _repository.GetCarBrandAndModelWithHighestDailyRentPrice()),
                CarBrandAndModelWithLowestDailyRentPrice = await Task.Run(() => _repository.GetCarBrandAndModelWithLowestDailyRentPrice())
            };

            return statistics;
        }
    }
}
