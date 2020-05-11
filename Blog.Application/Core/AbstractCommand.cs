using AutoMapper;
using FluentValidation.Results;
using MediatR;
using System;

namespace Blog.Application.Core
{
    public abstract class AbstractCommand : IRequest
    {
        protected AbstractCommand()
        {
            this.Timestamp = DateTime.Now;
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// 验证结果
        /// </summary>
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
