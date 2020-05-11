using Blog.Application.Core.User.Validations;
using System;

namespace Blog.Application.Core.User.Commands
{
    public class UpdateUserCommand : AbstractCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public override bool IsValid()
        {
            this.ValidationResult = new UpdateUserValidation().Validate(this);
            return this.ValidationResult.IsValid;
        }
    }
}
