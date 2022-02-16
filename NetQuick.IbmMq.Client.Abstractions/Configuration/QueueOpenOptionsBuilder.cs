namespace NetQuick.IbmMq.Client
{

    public class QueueOpenOptionsBuilder
    {
        private int _options;

        /// <summary>
        /// Open queue to get messages using the queue-defined defaults.
        /// </summary>
        /// <returns></returns>
        public QueueOpenOptionsBuilder OpenForInputWithDefaultsFromQueueDefinition()
        {
            _options |= (int)MqOpenOptions.MQOO_INPUT_AS_Q_DEF;
            return this;
        }
        public QueueOpenOptionsBuilder OpenForBrowsing()
        {
            _options |= (int)MqOpenOptions.MQOO_BROWSE;
            return this;
        }
        /// <summary>
        /// Opens the queue for input with shared access or exclusive access.
        /// </summary>
        /// <param name="useSharedAccess"></param>
        /// <returns></returns>
        public QueueOpenOptionsBuilder OpenForInputWithSharedAccess(bool useSharedAccess = true)
        {
            if (useSharedAccess)
            {
                _options |= (int)MqOpenOptions.MQOO_INPUT_SHARED;
            }
            else
            {
                _options |= (int)MqOpenOptions.MQOO_INPUT_EXCLUSIVE;
            }

            return this;
        }

        /// <summary>
        /// Open queue to put messages. Or opens a topic or topic string to publish messages.
        /// </summary>
        /// <returns></returns>
        public QueueOpenOptionsBuilder OpenForOutput()
        {
            _options |= (int)MqOpenOptions.MQOO_OUTPUT;
            return this;
        }

        public int Build()
        {
            return _options;
        }
    }

}
