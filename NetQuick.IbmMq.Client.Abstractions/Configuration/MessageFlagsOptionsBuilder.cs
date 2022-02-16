namespace NetQuick.IbmMq.Client
{

    public class MessageFlagsOptionsBuilder
    {
        private int _messageFlags = 0;

        /// <summary>
        /// This option allows the message to be broken into segments by the queue manager or indicates that this message is member of a group.
        /// </summary>
        /// <param name="allowSegmentation">If set to true this message is member of a group, If set to false this allows the message to be broken into segments by the queue manager.</param>
        /// <returns></returns>
        public MessageFlagsOptionsBuilder AllowSegmentation(bool allowSegmentation = true)
        {
            _messageFlags |= allowSegmentation ? (int)MqMessageFlags.MQMF_SEGMENTATION_ALLOWED : (int)MqMessageFlags.MQMF_SEGMENTATION_INHIBITED;
            return this;
        }

        public MessageFlagsOptionsBuilder SetAsSegmentOfLogicalMessage(SegmentType segmentType = SegmentType.Segment)
        {
            switch(segmentType)
            {
                case SegmentType.LastSegment:
                    _messageFlags |= (int)MqMessageFlags.MQMF_LAST_SEGMENT;
                    break;
                case SegmentType.Segment:
                    _messageFlags |= (int)MqMessageFlags.MQMF_SEGMENT;
                    break;
                default:
                    break;
            }
            return this;
        }

        public int Build()
        {
            return _messageFlags;
        }
    }
}