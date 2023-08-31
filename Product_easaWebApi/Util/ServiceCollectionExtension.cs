using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product_Easa_Commends.ProductCommends.Commend;
using Product_Easa_Commends.ProductCommends.CommendHandler;
using Product_Easa_Commends.ProductCommends.Query;
using Product_Easa_Commends.ProductCommends.QueryHandler;
using Product_Easa_Models.Core;
using System.Reflection;

namespace Product_easaWebApi.Util;

public static class ServiceCollectionExtension
{
    public static void ConfigureControllers(this IServiceCollection services)
    {
        _ = services.AddControllers(config =>
        {
            config.CacheProfiles.Add("30SecondsCaching", new CacheProfile
            {
                Duration = 30
            });
        });
    }
    public static void ConfigureResponseCaching(this IServiceCollection services)
    {
        services.AddResponseCaching();
    }
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
    }





    public static void AddCommendTransients(this IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>, GetAllProductsQueryHandler>();
        services.AddTransient<IRequestHandler<GetProductQuery, Product>, GetProductQueryHandler>();
        services.AddTransient<IRequestHandler<AddProductCommend, Product>, AddProductCommendHandler>();
        services.AddTransient<IRequestHandler<UpdateProductCommend, Product>, UpdateProductCommendHandler>();
        services.AddTransient<IRequestHandler<RemoveProductCommend, int>, RemoveProductCommendHandler>();
    }
}
