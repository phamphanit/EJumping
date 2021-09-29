using EJumping.Application.Services;
using EJumping.CrossCuttingConcerns.OS;
using EJumping.Domain.Services;
using EJumping.Infrastructure.OS;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Application
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IQuestionService, QuestionService>();
            return services;
        }
    }
}
