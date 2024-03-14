
namespace NotificationSMS.Service.AWSSMS
{
    public class SmsMessage : ISmsMessage
    {
        public DateTime Date { get; set; }
        public DateTime? DateSent { get; set; }
        public string SenderName { get; set; }
        public string Text { get; set; }
        public string To { get; set; }
        public int Retries { get; set; }
    }
}
