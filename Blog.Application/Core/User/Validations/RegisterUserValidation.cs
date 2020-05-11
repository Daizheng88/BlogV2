using Blog.Application.Core.User.Commands;
using FluentValidation;

namespace Blog.Application.Core.User.Validations
{
    public class RegisterUserValidation : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidation()
        {
            ValidateEMail();
            ValidateName();
            ValidatePassword();
        }

        protected void ValidateEMail()
        {
            this.RuleFor(i => i.EMail)
                .Matches(@"^(\w+((-\w+)|(\.\w+))*)\+\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$")
                .WithMessage("邮箱格式不正确")
                ;
        }

        protected void ValidateName()
        {
            this.RuleFor(i => i.Name)
                .Length(1, 12)
                .WithMessage("昵称长度超出限制(12字符)")
                ;
        }

        protected void ValidatePassword()
        {
            this.RuleFor(i => i.Password)
                .NotEmpty()
                .WithMessage("密码不能为空")
                ;
        }
    }
}
