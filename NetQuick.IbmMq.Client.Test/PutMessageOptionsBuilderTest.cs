using Xunit;

namespace NetQuick.IbmMq.Client.Test
{
    public class PutMessageOptionsBuilderTest
    {
        [Fact]
        public void Test1()
        {
            var builder = new PutMessageOptionsBuilder();
            builder
                .UseAsyncResponse()
                .UseSyncPointControl()
                .AssociateDefaultContext()
                .GenerateNewCorrelationId()
                .UseDefaultResponseType()
                .GenerateNewMessageId();
                
            var options = builder.Build();
        }
    }
}
