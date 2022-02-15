namespace NetQuick.IbmMq.Client
{
    public enum QueueInput
    {
        AsQueueDefinintion = 1,
        Shared = 2,
        Exclusive = 4
    }

    public class QueueOpenOptionsBuilder
    {
        private int _options;

        public QueueOpenOptionsBuilder OpenForInputWithDefaultsFromQueueDefinition()
        {
            _options |= (int)MqOpenOptions.MQOO_INPUT_AS_Q_DEF;
            return this;
        }

        public QueueOpenOptionsBuilder OpenWithSharedAccess(bool useSharedAccess = true)
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
