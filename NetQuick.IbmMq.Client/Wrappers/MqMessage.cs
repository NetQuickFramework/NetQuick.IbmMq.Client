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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            _innerMessage = innerMessage;          
            _encoding = Encoding.GetEncoding(_innerMessage.CharacterSet);

        }

        public MqMessage()
        {
            _encoding = Encoding.UTF8;

            _innerMessage = new MQMessage
            {
                CharacterSet = _encoding.CodePage
            };
        }

        private Encoding _encoding;

        public Encoding Encoding
        {
            get
            {
                if (_encoding == null)
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    _encoding = Encoding.GetEncoding(_innerMessage.CharacterSet);
                }
                return _encoding;
            }
            set
            {
                _innerMessage.CharacterSet = value.CodePage;            
            }
        }

        public int BackoutCount
        {
            get { return _innerMessage.BackoutCount; }
        }

        public void WriteString(string value)
        {
            _innerMessage.WriteString(value);
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

        internal MQMessage GetInternalMessage()
        {
            return _innerMessage;
        }

        public int Version
        {

            get { return _innerMessage.Version; }
            set { _innerMessage.Version = value; }
        }

        public string ReadString(int length)
        {           
            return _innerMessage.ReadString(length); 
        }

        public void WithMessageFlags(Action<MessageFlagsOptionsBuilder> messageFlagsOptionsBuilderAction)
        {
            var messageFlagsOptionsBuilder = new MessageFlagsOptionsBuilder();
            messageFlagsOptionsBuilderAction.Invoke(messageFlagsOptionsBuilder);

            _innerMessage.MessageFlags = messageFlagsOptionsBuilder.Build();
        }
    }
}
