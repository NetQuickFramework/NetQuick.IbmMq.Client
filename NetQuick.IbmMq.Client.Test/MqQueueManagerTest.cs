using System;
using Xunit;

namespace NetQuick.IbmMq.Client.Test
{
    public class MqQueueManagerTest
    {
        [Fact]
        public void Test()
        {
            var queueManager = new MqQueueManager("QM1", properties => properties.WithChannel("DEV.APP.INS.CONN").WithHostname("localhost"));
            var queue = queueManager.AccessQueue("DEV.QUEUE.1", options => options
            .OpenForOutput()
            .OpenForInputWithDefaultsFromQueueDefinition());
            var message = new MqMessage();
            message.SetMessageFlags(flags => flags.AllowSegmentation()
                                                  .SetAsSegmentOfLogicalMessage());
            message.Encoding = System.Text.Encoding.UTF8;
            message.Expiry = TimeSpan.FromMinutes(60);
            
            queue.Put(message);

            var resultMessage = new MqMessage();
            queue.Get(resultMessage);
        }
    }
}
