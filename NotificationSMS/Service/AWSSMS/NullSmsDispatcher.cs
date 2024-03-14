namespace NotificationSMS.Service.AWSSMS
{
    public class NullSmsDispatcher : ISmsDispatcher
    {
        public Task Dispatch(ISmsMessage sms) => Task.CompletedTask;
    }
}
