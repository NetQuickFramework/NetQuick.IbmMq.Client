namespace NetQuick.IbmMq.Client
{
    public enum MqPutMessageOptions
    {
        MQPMO_DEFAULT_CONTEXT = 32,
        MQPMO_NO_CONTEXT = 16384,
        MQPMO_ASYNC_RESPONSE = 65536,
        MQPMO_SYNC_RESPONSE = 131072,
        MQPMO_SYNCPOINT = 2,
        MQPMO_NO_SYNCPOINT = 4,
        MQPMO_NEW_CORREL_ID = 128,
        MQPMO_NEW_MSG_ID = 64,
        MQPMO_RESPONSE_AS_Q_DEF = 0
    }
}
