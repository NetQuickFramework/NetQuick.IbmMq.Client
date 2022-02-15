namespace NetQuick.IbmMq.Client
{
    public enum MqMessageFlags
    {
        MQMF_SEGMENTATION_INHIBITED = 0,
        MQMF_SEGMENTATION_ALLOWED = 1,
        MQMF_SEGMENT = 2,
        MQMF_LAST_SEGMENT = 4,        
    }
}