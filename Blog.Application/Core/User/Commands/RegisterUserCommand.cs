using Blog.Application.Core.User.Validations;

namespace Blog.Application.Core.User.Commands
{
    public class RegisterUserCommand : AbstractCommand
    {
        public string Password { get; set; }

        public string EMail { get; set; }

        public string Name { get; set; }

        public override bool IsValid()
        {
            this.ValidationResult = new RegisterUserValidation().Validate(this);
            return this.ValidationResult.IsValid;
        }
    }
}
