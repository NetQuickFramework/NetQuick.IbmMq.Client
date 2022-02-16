using System;

namespace NetQuick.IbmMq.Client
{
    public interface IMqQueueManager
    {
        IMqQueue AccessQueue(string queueName, Action<QueueOpenOptionsBuilder> openOptionsBuilderAction);
        IMqQueue AccessQueue(string queueName, int openOptions);
        /// <summary>
        /// Backout a unit of work.
        /// </summary>
        void Backout();
        /// <summary>
        /// Commit a unit of work.
        /// </summary>
        void Commit();
    }
}
