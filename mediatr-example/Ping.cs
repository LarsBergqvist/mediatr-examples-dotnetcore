using System;
using MediatR;

namespace mediatr_example
{
    public class Ping : IRequest<Pong>
    {
        public string Message { get; set; }
    }
}
