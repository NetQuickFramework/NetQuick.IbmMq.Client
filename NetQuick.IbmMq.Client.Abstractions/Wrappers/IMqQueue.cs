using System;

namespace NetQuick.IbmMq.Client
{
    public interface IMqQueue
    {
        void Get(IMqMessage message);
        /// <summary>
        /// Checks if the queue is open
        /// </summary>
        bool IsOpen { get; }
        /// <summary>
        /// Puts a message on a queue, distribution list, or to a topic. The queue, distribution list or topic must already be open.
        /// </summary>
        /// <param name="message">The message to put on the queue</param>
        void Put(IMqMessage message);
        /// <summary>
        /// Puts a message on a queue, distribution list, or to a topic. The queue, distribution list or topic must already be open.
        /// </summary>        
        /// <param name="message">The message to put on the queue</param>
        /// <param name="sendMessageOptionsBuilderAction">The options to be used when putting the message on a queue.</param>
        void Put(IMqMessage message, Action<PutMessageOptionsBuilder> sendMessageOptionsBuilderAction);
        void Close();
    }
}
