namespace NetQuick.IbmMq.Client
{

    public class PutMessageOptionsBuilder
    {
        private int _options;

        /// <summary>
        /// Associate default context with the message.
        /// </summary>
        /// <returns></returns>
        public PutMessageOptionsBuilder AssociateDefaultContext(bool associateDefaultContext = true)
        {
            if (associateDefaultContext)
            {
                _options |= (int)MqPutMessageOptions.MQPMO_DEFAULT_CONTEXT;
            }
            else
            {
                _options |= (int)MqPutMessageOptions.MQPMO_NO_CONTEXT;
            }

            return this;
        }

        /// <summary>
        /// This option causes the MQDestination.put call to be made asynchronously, with some response data. Otherwise when this option is false causes the MQDestination.put or MQQueueManager.put call to be made synchronously, with full response data.
        /// </summary>
        /// <returns></returns>
        public PutMessageOptionsBuilder UseAsyncResponse(bool useAsyncResponse = true)
        {
            if (useAsyncResponse)
            {
                _options |= (int)MqPutMessageOptions.MQPMO_ASYNC_RESPONSE;
            }
            else
            {
                _options |= (int)MqPutMessageOptions.MQPMO_SYNC_RESPONSE;
            }
            return this;
        }

        /// <summary>
        /// Put a message with sync point control. The message is not visible outside the unit of work until the unit of work is committed. If the unit of work is backed out, the message is deleted.
        /// </summary>
        /// <returns></returns>
        public PutMessageOptionsBuilder UseSyncPointControl(bool useSyncPointControl = true)
        {
            if (useSyncPointControl)
            {
                _options |= (int)MqPutMessageOptions.MQPMO_SYNCPOINT;
            }
            else
            {
                _options |= (int)MqPutMessageOptions.MQPMO_NO_SYNCPOINT;
            }

            return this;
        }

        /// <summary>
        /// Generate a new correlation ID for each sent message.
        /// </summary>
        /// <returns></returns>
        public PutMessageOptionsBuilder GenerateNewCorrelationId()
        {
            _options |= (int)MqPutMessageOptions.MQPMO_NEW_CORREL_ID;
            return this;
        }

        /// <summary>
        /// Generate a new message ID for each sent message.
        /// </summary>
        /// <returns></returns>
        public PutMessageOptionsBuilder GenerateNewMessageId()
        {
            _options |= (int)MqPutMessageOptions.MQPMO_NEW_MSG_ID;
            return this;
        }

        /// <summary>
        /// Uses the default response type (sychronious or asynchronious) from the queue definition.
        /// This options overrides the value of <see cref="UseAsyncResponse"/>.
        /// </summary>
        /// <returns></returns>
        public PutMessageOptionsBuilder UseDefaultResponseType()
        {
            _options |= (int)MqPutMessageOptions.MQPMO_RESPONSE_AS_Q_DEF;
            return this;
        }

        public int Build()
        {
            return _options;
        }
    }
}
