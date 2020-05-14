using Blog.Application.Core.User.Commands;
using Blog.Core.Repositories.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Application.Core.User.Handlers
{
    public class UpdateUserHandler : CommandHandler, IRequestHandler<UpdateUserCommand, Unit>
    {
        public IUserRepository UserRepository { get; set; }

        public Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // 验证指令是否有效
            if (!request.IsValid())
            {
                this.Notifier.NoticeErrors(request.ValidationResult);
                return Unit.Task;
            }

            // 检查数据库是否存在一致的名称
            return Unit.Task;
        }
    }
}
