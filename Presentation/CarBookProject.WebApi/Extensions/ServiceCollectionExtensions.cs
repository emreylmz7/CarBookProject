﻿using CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.CarHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBookProject.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBookProject.Application.Interfaces.CarInterfaces;
using CarBookProject.Application.Interfaces;
using CarBookProject.Persistence.Context;
using CarBookProject.Persistence.Repositories.CarRepositories;
using CarBookProject.Persistence.Repositories;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using CarBookProject.Persistence.Repositories.BlogRepositories;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using CarBookProject.Persistence.Repositories.CarPricingRepositories;
using CarBookProject.Application.Interfaces.CommentInterfaces;
using CarBookProject.Persistence.Repositories.CommentRepositories;
using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using CarBookProject.Persistence.Repositories.StatisticsRepositories;
using CarBookProject.Application.Interfaces.RentACarInterfaces;
using CarBookProject.Persistence.Repositories.RentACarRepositories;
using CarBookProject.Application.Interfaces.CarFeatureInterfaces;
using CarBookProject.Persistence.Repositories.CarFeatureRepositories;
using CarBookProject.Application.Interfaces.FeatureInterfaces;
using CarBookProject.Persistence.Repositories.FeatureRepositories;
using CarBookProject.Application.Interfaces.ReservationInterfaces;
using CarBookProject.Persistence.Repositories.ReservationRepositories;
using CarBookProject.Application.Interfaces.CarDescriptionInterfaces;
using CarBookProject.Persistence.Repositories.CarDescriptionRepositories;
using CarBookProject.Application.Interfaces.AuthenticationInterfaces;
using CarBookProject.Persistence.Repositories.AuthenticationRepositories;
using CarBookProject.Application.Interfaces.ReviewInterfaces;
using CarBookProject.Persistence.Repositories.ReviewRepositories;
using CarBookProject.Persistence.Repositories.PaymentRepositories;
using CarBookProject.Application.Interfaces.PaymentInterfaces;
using CarBookProject.Application.Interfaces.InvoiceInterfaces;
using CarBookProject.Persistence.Repositories.InvoiceRepositories;

namespace CarBookProject.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<CarBookContext, CarBookContext>();

            #region Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
            services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
            services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));
            services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
            services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
            services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
            services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
            services.AddScoped(typeof(IFeatureRepository), typeof(FeatureRepository));
            services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));
            services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
            services.AddScoped(typeof(IAuthenticatedUserRepository), typeof(AuthenticatedUserRepository));
            services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
            services.AddScoped(typeof(IPaymentRepository), typeof(PaymentRepository));
            services.AddScoped(typeof(IInvoiceRepository), typeof(InvoiceRepository));
            #endregion

            #region Handlers
            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();

            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();

            services.AddScoped<GetBrandQueryHandler>();
            services.AddScoped<GetBrandByIdQueryHandler>();
            services.AddScoped<CreateBrandCommandHandler>();
            services.AddScoped<UpdateBrandCommandHandler>();
            services.AddScoped<RemoveBrandCommandHandler>();

            services.AddScoped<GetCarQueryHandler>();
            services.AddScoped<GetCarByIdQueryHandler>();
            services.AddScoped<CreateCarCommandHandler>();
            services.AddScoped<UpdateCarCommandHandler>();
            services.AddScoped<RemoveCarCommandHandler>();
            services.AddScoped<GetCarWithBrandQueryHandler>();

            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();

            services.AddScoped<GetContactQueryHandler>();
            services.AddScoped<GetContactByIdQueryHandler>();
            services.AddScoped<CreateContactCommandHandler>();
            services.AddScoped<UpdateContactCommandHandler>();
            services.AddScoped<RemoveContactCommandHandler>();
            #endregion
        }
    }
}
