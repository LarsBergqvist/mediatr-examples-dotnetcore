using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace mediatr_example
{
    public class MyNotificationHandler1 : INotificationHandler<MyNotification>
    {
        private readonly TextWriter _writer;

        public MyNotificationHandler1(TextWriter writer)
        {
            _writer = writer;
        }
        public async Task Handle(MyNotification notification, CancellationToken cancellationToken)
        {
            await _writer.WriteLineAsync($"Got notification in handler 1");
        }
    }
}
