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
            var mediator = BuildMediator();

            // Send a request that returns a response (a query)
            var res = await mediator.Send(new Ping() { Message = "ping!" });
            Console.WriteLine(res.Message);

            // Send a request that returns no response (a command)
            await mediator.Send(new Jing() { Message = "jing!" });

            // Publish a notification (an event)
            await mediator.Publish(new MyNotification());
        }

        private static IMediator BuildMediator()
        {
            //
            // Setup dependency injection
            //

            var services = new ServiceCollection();

            services.AddSingleton<TextWriter>(Console.Out);

            // Register all requests, notifictions and handlers in this assembly
            services.AddMediatR(typeof(Program));

            var provider = services.BuildServiceProvider();

            return provider.GetRequiredService<IMediator>();
        }
    }
}
