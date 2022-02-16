using IBM.WMQ;
using System.Collections;

namespace NetQuick.IbmMq.Client
{
    public class MqQueueManagerPropertiesBuilder
    {
        private Hashtable _properties;

        public MqQueueManagerPropertiesBuilder()
        {
            _properties = new Hashtable();
        }

        public MqQueueManagerPropertiesBuilder WithHostname(string hostname)
        {
            _properties.Add(MQC.HOST_NAME_PROPERTY, hostname);
            return this;
        }

        public MqQueueManagerPropertiesBuilder WithChannel(string channel)
        {
            _properties.Add(MQC.CHANNEL_PROPERTY, channel);
            return this;
        }

        public Hashtable Build()
        {
            return _properties;
        }
    }
}
