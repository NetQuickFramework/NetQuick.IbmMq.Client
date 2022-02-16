using IBM.WMQ;
using System;

namespace NetQuick.IbmMq.Client
{

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
        
        public void Backout()
        {
            _queueManager.Backout();
        }
       
        public void Commit()
        {
            _queueManager.Commit();
        }

        public IMqQueue AccessQueue(string queueName, int openOptions)
        {
            return new MqQueue(_queueManager.AccessQueue(queueName, openOptions));          
        }        
    }
}
