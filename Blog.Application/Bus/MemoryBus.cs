using Blog.Application.Core;
using MediatR;
using System.Threading.Tasks;

namespace Blog.Application.Bus
{
    public class MemoryBus : IMediatorHandler
    {
        public MemoryBus(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        public IMediator Mediator { get; }

        public Task SendCommand<T>(T command) where T : AbstractCommand
        {
            return this.Mediator.Send(command);
        }
    }
}
