namespace NotificationSMS.Service.AWSSMS
{
    public class SmsService : ISmsService
    {
        readonly ILogger<SmsService> Log;
        ISmsDispatcher Dispatcher;
        int MaximumRetries = 3;
        private readonly IConfiguration _configuration;

        public SmsService(ISmsDispatcher dispatcher, ILogger<SmsService> log, IConfiguration configuration)
        {
            Dispatcher = dispatcher;
            Log = log;
            this._configuration = configuration;
        }

        public async Task<bool> Send(ISmsMessage smsItem)
        {
            if (smsItem.Retries > MaximumRetries)
                return false;
            try
            {

                await Dispatcher.Dispatch(smsItem);
                return true;
            }
            catch (Exception ex)
            {
                Log.LogError("Can not send the SMS queue item.");
                await RecordFailedAttempt(smsItem);
                return false;
            }
        }

        /// <summary>
        /// Records an unsuccessful attempt to send this SMS.
        /// </summary>
        public async Task RecordFailedAttempt(ISmsMessage sms)
        {
            // Also update this local instance:
            sms.Retries++;
        }

        ///// <summary>
        ///// Updates the DateSent field of this item and then soft deletes it.
        ///// </summary>
        //public Task MarkSent(ISmsMessage sms)
        //{
        //    return Database.EnlistOrCreateTransaction(() => Database.Update(sms, o => o.DateSent = LocalTime.Now));
        //}

        //public async Task SendAll()
        //{
        //    foreach (var sms in await Database.GetList<ISmsMessage>(i => i.DateSent == null))
        //        await Send(sms);
        //}
    }
}
