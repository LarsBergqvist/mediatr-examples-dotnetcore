﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace mediatr_example
{
    public class PingHandler : IRequestHandler<Ping, Pong>
    {
        private readonly TextWriter _writer;

        public PingHandler(TextWriter writer)
        {
            _writer = writer;
        }

        public async Task<Pong> Handle(Ping request, CancellationToken cancellationToken)
        {
            await _writer.WriteLineAsync($"Handled Ping: {request.Message}");
            return new Pong { Message = "Pong, response from ping" };
        }
    }
}
