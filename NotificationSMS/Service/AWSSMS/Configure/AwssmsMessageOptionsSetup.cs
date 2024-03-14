using Microsoft.Extensions.Options;
namespace NotificationSMS.Service.AWSSMS.Configure
{
    public class AwssmsMessageOptionsSetup : IConfigureOptions<AwssmsMessageOptions>
    {
        private const string ConfigurationSectionName = "AwssmsMessageOptions";
        private readonly IConfiguration _configuration;

        public AwssmsMessageOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(AwssmsMessageOptions options)
        {
            _configuration.GetSection(ConfigurationSectionName).Bind(options);
        }
    }
}
