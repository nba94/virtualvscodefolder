namespace Core_Meeting_16.Services
{
    public class EmailMessageSender : IMessageSender
    {
        public string Send()
        {
            return "Сообщение отправлено по e-mail";
        }
    }
}