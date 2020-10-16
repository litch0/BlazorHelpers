using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace BlazorHelper.Jquery
{
    public static class JqueryService
    {
        public static IServiceCollection AddJquery(this IServiceCollection services)
        {
            services.AddSingleton<Jquery>();
            Console.WriteLine("Jquery added");
            return services;
        }
    }

    public class Jquery
    {
        public static IJSRuntime Runtime;
        public Jquery(IJSRuntime runtime)
        {
            Runtime = runtime;
            Console.WriteLine("Runtime is added");
        }
    }
}