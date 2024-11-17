using Finance.Application.Commands.CreateIncome;
using Finance.Application.Commands.CreatePaymentType;
using Finance.Application.Models;
using Finance.Application.Queries.GetUserById;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers()
                .AddValidation();

            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<GetUserByIdQuery>());




            return services;
        }

        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreatePaymentTypeCommand>();

            services.AddTransient<IPipelineBehavior<CreateIncomeCommand, ResultViewModel<int>>, ValidateCreateIncomeCommandBehavior>(); 

            return services;
        }
    }
}
