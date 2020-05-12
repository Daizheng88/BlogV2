using AutoMapper;
using Blog.Application.Bus;
using Blog.Application.Bus.Notify;
using Blog.Core.UnitOfWork;

namespace Blog.Application.Core
{
    public class CommandHandler
    {
        public IMediatorHandler Bus { get; set; }

        public IUnitOfWork UnitOfWork { get; set; }

        public INotifier Notifier { get; set; }

        public IMapper Mapper { get; set; }
    }
}
