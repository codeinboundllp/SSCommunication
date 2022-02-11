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
        private static bool IsCommonAdded = false;

        public static IServiceCollection AwsEmailConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            var awsconfig = new AwsConfiguration();
            configuration.Bind(nameof(SSCommunicationsConfig) + ":" + nameof(AwsConfiguration), awsconfig);
            services.AddSingleton<IEmailService>(new AwsEmailServices(awsconfig));
            services.CommonConfig();
            return services;
        }
        public static IServiceCollection SMTPEmailConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            var smtpconfig = new SMTPConfiguration();
            configuration.Bind(nameof(SSCommunicationsConfig) + ":" + nameof(SMTPConfiguration), smtpconfig);
            services.AddSingleton<IEmailService>(new SMTPEmailService(smtpconfig));
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
            if (!IsCommonAdded)
            {
                services.AddSingleton<IGenericHttpResponse, CommonGenericResponse>();
                IsCommonAdded = true;
                return services;
            }
            else
            {
                return services;
            }
        }
        public static IServiceCollection AddBackgroundTaskQueue(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            services.AddHostedService<QueuedHostedService>();
            return services;
        }

    }
}
