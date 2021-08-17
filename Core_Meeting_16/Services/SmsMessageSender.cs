namespace Core_Meeting_16.Services
{
    public class SmsMessageSender : IMessageSender
    {
        public string Send()
        {
            return "Сообщение отправлено по SMS";
        }
    }
}