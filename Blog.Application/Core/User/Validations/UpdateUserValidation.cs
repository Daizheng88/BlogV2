using Blog.Application.Core.User.Commands;
using FluentValidation;

namespace Blog.Application.Core.User.Validations
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidation()
        {
            ValidateId();
            ValidateName();
        }

        protected void ValidateId()
        {
            this.RuleFor(i => i.Id)
                .NotEmpty()
                .WithMessage("Id不能为空")
                ;
        }

        protected void ValidateName()
        {
            this.RuleFor(i => i.Name)
                .NotEmpty()
                .WithMessage("昵称不能为空")
                .MaximumLength(12)
                .WithMessage("昵称超出最大限制(12字符)")
                ;
        }
    }
}
