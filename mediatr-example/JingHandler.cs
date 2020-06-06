using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace mediatr_example
{
    public class JingHandler : AsyncRequestHandler<Jing>
    {
        private readonly TextWriter _writer;

        public JingHandler(TextWriter writer)
        {
            _writer = writer;
        }

        protected override async Task Handle(Jing request, CancellationToken cancellationToken)
        {
            await _writer.WriteLineAsync($"Handled Jing: {request.Message}");
            return;
        }
    }
}
