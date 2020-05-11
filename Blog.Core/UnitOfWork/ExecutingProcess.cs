using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.UnitOfWork
{
    public class ExecutingProcess
    {
        public ExecutingProcess(bool success, int affected, Exception exception = null)
        {
            this.Success = success;
            this.Affected = affected;
            this.Exception = exception;
        }

        /// <summary>
        /// 是否执行成功
        /// </summary>
        private bool Success { get; set; }

        /// <summary>
        /// 影响的行数
        /// </summary>
        private int Affected { get; set; }
        
        /// <summary>
        /// 异常信息
        /// </summary>
        private Exception Exception { get; set; }

        /// <summary>
        /// 当程序正常执行时返回
        /// </summary>
        public ExecutingProcess Then(Action<bool, int> action)
        {
            if (action != null)
            {
                action.Invoke(Success, Affected);
            }

            return this;
        }

        /// <summary>
        /// 当程序正常执行且执行成功时
        /// </summary>
        /// <returns></returns>
        public ExecutingProcess ThenSuccess(Action<int> action)
        {
            if (action != null && Success)
            {
                action.Invoke(Affected);
            }

            return this;
        }

        /// <summary>
        /// 当程序执行错误时返回
        /// </summary>
        public ExecutingProcess Catch(Action<Exception> action)
        {
            if (action != null)
            {
                action.Invoke(Exception);
            }

            return this;
        }
    }
}
