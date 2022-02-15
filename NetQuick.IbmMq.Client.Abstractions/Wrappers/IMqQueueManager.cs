using System;

namespace NetQuick.IbmMq.Client
{
    public interface IMqQueueManager
    {
        IMqQueue AccessQueue(string queueName, Action<QueueOpenOptionsBuilder> openOptionsBuilderAction);
        IMqQueue AccessQueue(string queueName, int openOptions);
    }
}
