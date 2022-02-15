using IBM.WMQ;
using System;
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

    public class MqQueueManager : IMqQueueManager
    {
        private MQQueueManager _queueManager;

        public MqQueueManager(string queueManagerName)
        {
            _queueManager = new MQQueueManager(queueManagerName);           
        }

        public MqQueueManager(string queueManagerName, Action<MqQueueManagerPropertiesBuilder> mqQueueManagerPropertiesBuilderAction)
        {
            var mqQueueManagerPropertiesBuilder = new MqQueueManagerPropertiesBuilder();
            mqQueueManagerPropertiesBuilderAction.Invoke(mqQueueManagerPropertiesBuilder);
            var properties = mqQueueManagerPropertiesBuilder.Build();

            _queueManager = new MQQueueManager(queueManagerName, properties);
        }

        public IMqQueue AccessQueue(string queueName, Action<QueueOpenOptionsBuilder> openOptionsBuilderAction)
        {
            var openOptionsBuilder = new QueueOpenOptionsBuilder();
            openOptionsBuilderAction.Invoke(openOptionsBuilder);
            var options = openOptionsBuilder.Build();

            return AccessQueue(queueName, options);
        }      

        public IMqQueue AccessQueue(string queueName, int openOptions)
        {
            return new MqQueue(_queueManager.AccessQueue(queueName, openOptions));
        }        
    }
}
