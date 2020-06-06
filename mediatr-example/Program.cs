using System;
using System.IO;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace mediatr_example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var mediator = BuildMediator();

            // A request with a response
            var res = await mediator.Send(new Ping() { Message = "ping" });
            Console.WriteLine(res.Message);

            // A request without a response
            await mediator.Send(new Jing() { Message = "jing!" });

            await mediator.Publish(new MyNotification());
        }

        private static IMediator BuildMediator()
        {
            var services = new ServiceCollection();

            services.AddSingleton<TextWriter>(Console.Out);

            // Register all requests and handlers in this assembly
            services.AddMediatR(typeof(Program));

            var provider = services.BuildServiceProvider();

            return provider.GetRequiredService<IMediator>();
        }
    }
}
