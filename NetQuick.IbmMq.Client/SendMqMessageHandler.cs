//using IBM.WMQ;
//using System;

//namespace NetQuick.IbmMq.Client
//{
//    public class SendMqMessageHandler
//    {
//        private readonly IMqQueueManager _mqQueueManager;

//        public SendMqMessageHandler(IMqQueueManager mqQueueManager)
//        {
//            if (mqQueueManager is null)
//            {
//                throw new ArgumentNullException(nameof(mqQueueManager));
//            }
//            _mqQueueManager = mqQueueManager;
//        }

//        public SendMqMessageResponse Handle(SendMqMessageRequest request, Action<PutMessageOptionsBuilder> optionsBuilderAction = null)
//        {
//            var options = new MQPutMessageOptions();

//            if (optionsBuilderAction != null)
//            {
//                var optionBuilder = new PutMessageOptionsBuilder();
//                optionsBuilderAction.Invoke(optionBuilder);

//                options = optionBuilder.Build();
//            }

//            var queue = _mqQueueManager.AccessQueue(request.Queue, optionsBuilderAction);

//            return new SendMqMessageResponse();
//        }
//    }
//}
