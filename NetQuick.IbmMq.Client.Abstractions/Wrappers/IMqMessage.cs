using System;
using System.Text;

namespace NetQuick.IbmMq.Client
{
    public interface IMqMessage
    {
        /// <summary>
        /// The accounting token. This is part of the identity of the message and it allows work done as a result of the message to be appropriately charged.
        /// </summary>
        string AccountingToken { get; }
        /// <summary>
        /// The number of times the message has been backed out.
        /// </summary>
        int BackoutCount { get; }
        /// <summary>
        /// The coded character set identifier of character data in the application message data.
        /// </summary>
        Encoding Encoding { get; set; }
        /// <summary>
        /// The expiry time.
        /// </summary>
        TimeSpan Expiry { get; set; }
        /// <summary>
        /// Gets or sets the version of this message
        /// </summary>
        int Version { get; set; }
        /// <summary>
        /// Sets the requested message flags for this message.
        /// </summary>
        /// <param name="messageFlagsOptionsBuilderAction"></param>        
        void SetMessageFlags(Action<MessageFlagsOptionsBuilder> messageFlagsOptionsBuilderAction);

    }
}