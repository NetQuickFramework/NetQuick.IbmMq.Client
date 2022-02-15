namespace NetQuick.IbmMq.Client
{
    public class SendMqMessageRequest
    {
        public string Queue { get; }

        public SendMqMessageRequest(string queue)
        {
            Queue = queue;
        }
    }
}
