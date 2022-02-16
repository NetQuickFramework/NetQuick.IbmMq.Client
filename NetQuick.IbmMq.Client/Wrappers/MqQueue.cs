using IBM.WMQ;
using System;

namespace NetQuick.IbmMq.Client
{
    public class MqQueue : IMqQueue
    {
        private MQQueue _queue;

        public MqQueue(MQQueue queue)
        {
            _queue = queue;
        }

        public void Close()
        {
            _queue.Close();            
        }

        public void Put(IMqMessage message)
        {
            _queue.Put(((MqMessage)message).GetInternalMessage());
        }

        public void Put(IMqMessage message, Action<PutMessageOptionsBuilder> sendMessageOptionsBuilderAction)
        {
            var optionsBuilder = new PutMessageOptionsBuilder();
            sendMessageOptionsBuilderAction.Invoke(optionsBuilder);

            var options = new MQPutMessageOptions() { Options = optionsBuilder.Build() };         

            Put(message, options);
        }

        public void Put(IMqMessage message, MQPutMessageOptions mqPutMessageOptions)
        {
            _queue.Put(((MqMessage)message).GetInternalMessage(), mqPutMessageOptions);
        }

        public bool IsOpen
        {
            get
            {
                return _queue.IsOpen;
            } 
        }

        public void Get(IMqMessage message)
        {
            var innerMessage = ((MqMessage)message).GetInternalMessage();
            _queue.Get(innerMessage);
            message = new MqMessage(innerMessage);
        }
    }

    public class GetMessageOptionsBuilder
    {
    }       
}
