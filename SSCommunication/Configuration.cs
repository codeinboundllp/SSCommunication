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
            configuration.Bind(nameof(SSCommunicationsConfig)+":"+nameof(AwsConfiguration), awsconfig);
            services.AddSingleton<IEmailService>(new AwsEmailServices(awsconfig));
            return services;
        }
      
    }
}
