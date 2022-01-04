using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSCommunication.Implementations;
using SSCommunication.Interfaces;
using SSCommunication.Models;
using System;

namespace SSCommunication
{
    public static class Configuration
    {
        public static IServiceCollection AwsEmailConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            var awsconfig = new AwsConfiguration();
            configuration.Bind(nameof(SSCommunicationsConfig) + ":" + nameof(AwsConfiguration), awsconfig);
            services.AddSingleton<IEmailService>(new AwsEmailServices(awsconfig));
            services.CommonConfig();
            return services;
        }
        public static IServiceCollection RecaptchaConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            var recaptcha_config = new RecaptchaConfiguration();
            configuration.Bind(nameof(SSCommunicationsConfig) + ":" + nameof(RecaptchaConfiguration), recaptcha_config);
            services.AddSingleton<ICaptchaService>(new RecaptchaService(recaptcha_config));
            services.CommonConfig();
            return services;
        }
        public static IServiceCollection CommonConfig(this IServiceCollection services)
        {
            services.AddSingleton<IGenericHttpResponse, CommonGenericResponse>();
            return services;
        }

    }
}
