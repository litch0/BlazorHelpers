using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorHelper.DOM
{
    public static class DOMService
    {
        public static IServiceCollection AddDOMHelper(this IServiceCollection s)
        {
            return s.AddSingleton<DOMHelper>();
        }
    }
}