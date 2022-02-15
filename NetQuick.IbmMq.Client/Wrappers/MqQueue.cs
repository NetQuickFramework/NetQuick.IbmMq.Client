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

        public void Put(IMqMessage message)
        {
            _queue.Put(message.GetMessage());
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
            _queue.Put(message.GetMessage(), mqPutMessageOptions);
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
            var innerMessage = message.GetMessage();
            _queue.Get(innerMessage);
            message = new MqMessage(innerMessage);
        }
    }

    public class GetMessageOptionsBuilder
    {
    }

    internal static class MessageConverter
    {
        public static MQMessage GetMessage(this IMqMessage internalMessage)
        {
            return new MQMessage()
            {
                //Encoding = // How to write integer values
                CharacterSet = internalMessage.Encoding.CodePage
            };
        }
    }    
}
