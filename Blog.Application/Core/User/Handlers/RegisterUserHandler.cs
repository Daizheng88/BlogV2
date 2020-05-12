using AutoMapper;
using Blog.Application.Bus;
using Blog.Application.Bus.Notify;
using Blog.Application.Core.User.Commands;
using Blog.Contract.Injections;
using Blog.Core.Repositories.User;
using Blog.Core.Repositories.User.Inputs;
using Blog.Core.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Application.Core.User.Handlers
{
    [Scope(Range = 2)]
    public class RegisterUserHandler : CommandHandler, IRequestHandler<RegisterUserCommand, Unit>, IRequestHandler<UpdateUserCommand, Unit>
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
