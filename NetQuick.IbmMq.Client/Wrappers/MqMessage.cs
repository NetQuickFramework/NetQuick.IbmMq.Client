using IBM.WMQ;
using System;
using System.Text;

namespace NetQuick.IbmMq.Client
{
    public class MqMessage : IMqMessage
    {
        private readonly MQMessage _innerMessage;

        internal MqMessage(MQMessage innerMessage)
        {
            _innerMessage = innerMessage;
        }

        public MqMessage()
        {
            _innerMessage = new MQMessage();
        }
      
        public Encoding Encoding
        {
            get { return Encoding.GetEncoding(_innerMessage.CharacterSet); }
            set { _innerMessage.CharacterSet = value.CodePage; }
        }
        
        public int BackoutCount
        {
            get { return _innerMessage.BackoutCount; }
        }
       
        public string AccountingToken
        {
            get { return _innerMessage.AccountingToken; }
        }
        
        public TimeSpan Expiry
        {
            get { return TimeSpan.FromMilliseconds(_innerMessage.Expiry * 100); }
            set { _innerMessage.Expiry = (int)value.TotalMilliseconds / 100; }
        }       
      
        public int Version
        {
            
            get { return _innerMessage.Version;  }
            set { _innerMessage.Version = value; }
        }
       
        public void SetMessageFlags(Action<MessageFlagsOptionsBuilder> messageFlagsOptionsBuilderAction)
        {
            var messageFlagsOptionsBuilder = new MessageFlagsOptionsBuilder();
            messageFlagsOptionsBuilderAction.Invoke(messageFlagsOptionsBuilder);

            _innerMessage.MessageFlags = messageFlagsOptionsBuilder.Build();
        }
    }
}
