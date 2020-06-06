using System;
using MediatR;

namespace mediatr_example
{
    public class Jing : IRequest
    {
        public string Message { get; set; }
    }
}
