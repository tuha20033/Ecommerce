
using Application.Abstractions.Repositories;
using AutoMapper.Configuration;
using Infrastructure.Data.Persistences;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Abstractions.UnitOfWork;
using Infrastructure.UnitOfWork;
namespace Infrastructure.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebPortalInfrastructure(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            var dbConn = configuration.GetConnectionString("DefaultConnection")
                         ?? configuration["ConnectionStrings:DefaultConnection"];

            if (string.IsNullOrWhiteSpace(dbConn))
                throw new InvalidOperationException("Missing connection string. Please set ConnectionStrings:DefaultConnection.");

            //services.AddDbContext<WebPortalDbContext>(options =>
            //{
            //    options.UseSqlServer(dbConn);
            //});

            services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlServer(dbConn), ServiceLifetime.Scoped);
            services.AddMemoryCache();


            //var redisConn = configuration.GetConnectionString("Redis")
            //                ?? configuration["ConnectionStrings:Redis"];

            //if (!string.IsNullOrWhiteSpace(redisConn))
            //{
            //    services.AddSingleton<IConnectionMultiplexer>(_ =>
            //        ConnectionMultiplexer.Connect(redisConn));
            //}
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAdressRepository, AddressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IWareHouseRepository, WarehouseRepository>();
            services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
            services.AddScoped<ICouponRepository, CouponRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IStockMovementRepository, StockMovementRepository>();
            services.AddScoped<IShipmentRepository, ShipmentRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IShippingCarrierRepository, ShippingCarrierRepository>();

            return services;
        }
    }
}
