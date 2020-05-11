﻿using Blog.Application.Core.User.Validations;

namespace Blog.Application.Core.User.Commands
{
    public class RegisteredUserCommand : AbstractCommand
    {
        public string EMail { get; set; }

        public string Name { get; set; }

        public override bool IsValid()
        {
            this.ValidationResult = new RegisteredUserValidation().Validate(this);
            return this.ValidationResult.IsValid;
        }
    }
}
