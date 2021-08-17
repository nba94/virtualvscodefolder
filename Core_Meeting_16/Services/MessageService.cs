namespace Core_Meeting_16.Services
{
    public class MessageService
    {
        private readonly IMessageSender _sender;
        
        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }

        public string SendMessage()
        {
            return _sender.Send();
        }
    }
}