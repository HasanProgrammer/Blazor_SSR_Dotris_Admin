using Microsoft.Extensions.DependencyInjection;

namespace Karami.Common.ClassExtensions;

public static class IServiceProviderExtension
{
    public static T GetScopeService<T>(this IServiceProvider ServiceProvider)
    {
        using IServiceScope Scope = ServiceProvider.CreateScope();
        return Scope.ServiceProvider.GetService<T>();
    }
}