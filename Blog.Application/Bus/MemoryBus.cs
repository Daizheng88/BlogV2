using Blog.Application.Core;
using Blog.Contract.Injections;
using MediatR;
using System.Threading.Tasks;

namespace Blog.Application.Bus
{
    [Scope]
    public class MemoryBus : IMediatorHandler
    {
        public IMediator Mediator { get; set; }

        public Task SendCommand<T>(T command) where T : AbstractCommand
        {
            return this.Mediator.Send(command);
        }
    }
}
