using Finance.Application.Queries.GetUserById;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers();

            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<GetUserByIdQuery>());

            return services;
        }
    }
}
