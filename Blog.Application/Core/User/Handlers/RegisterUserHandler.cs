using Blog.Application.Core.User.Commands;
using Blog.Contract.Injections;
using Blog.Core.Repositories.User;
using Blog.Core.Repositories.User.Inputs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Application.Core.User.Handlers
{
    [Scope]
    public class RegisterUserHandler : CommandHandler, IRequestHandler<RegisterUserCommand, Unit>
    {
        public IUserRepository UserRepository { get; set; }

        public Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // 验证指令是否有效
            if (!request.IsValid())
            {
                this.Notifier.NoticeErrors(request.ValidationResult);
                return Unit.Task;
            }

            // 通知仓储保存数据
            this.UserRepository.Insert(this.Mapper.Map<UserInput>(request));

            // 提交事务
            this.UnitOfWork.SaveChanges()
                .ThenSuccess(affected => this.Bus.SendCommand(this.Mapper.Map<RegisteredUserCommand>(request)))
                .Catch(exp => this.Notifier.NoticeError("服务异常"));

            return Unit.Task;
        }
    }
}
