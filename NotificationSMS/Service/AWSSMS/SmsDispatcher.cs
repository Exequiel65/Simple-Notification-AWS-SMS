using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Extensions.Options;
using NotificationSMS.Service.AWSSMS.Configure;

namespace NotificationSMS.Service.AWSSMS
{
    public class SmsDispatcher : ISmsDispatcher, IDisposable
    {
        private readonly AwssmsMessageOptions _awssmsMessageOptions;
        readonly AmazonSimpleNotificationServiceClient _client;
        readonly IConfiguration _configuration;

        public SmsDispatcher(IConfiguration configuration, IOptions<AwssmsMessageOptions> smsMessageOptions)
        {
            _awssmsMessageOptions = smsMessageOptions.Value;
            _configuration = configuration;
            _client = new AmazonSimpleNotificationServiceClient(_awssmsMessageOptions.AwsAccessKeyId, _awssmsMessageOptions.AwsSecretAccessKeyId, Amazon.RegionEndpoint.GetBySystemName(_awssmsMessageOptions.SystemName));
            //_client = new AmazonSimpleNotificationServiceClient(configuration.GetSection("AwssmsMessageOptions:AwsAccessKeyId").Value, configuration.GetSection("AwssmsMessageOptions:AwsSecretAccessKeyId").Value);
        }

        public async Task Dispatch(ISmsMessage sms)
        {
            var a = _awssmsMessageOptions;
            var request = new PublishRequest
            {
                Message = sms.Text,
                PhoneNumber = sms.To
            };

            try
            {
                var response = await _client.PublishAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Dispose()
        {
            _client.Dispose();
        }

    }
}
