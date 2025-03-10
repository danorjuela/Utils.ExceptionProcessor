using Danorjuela.Utils.ResponseProcessor.Interface;
using Danorjuela.Utils.ResponseProcessor.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Danorjuela.Utils.ResponseProcessor;

public static class AddServices
{
    public static IServiceCollection AddResponseProcessorService(this IServiceCollection services)
    {
        services.AddTransient<IResponseService, ResponseService>();
        return services;
    }
}

