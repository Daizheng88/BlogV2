using Blog.Application.Core;
using System.Threading.Tasks;

namespace Blog.Application.Bus
{
    /// <summary>
    /// 中介处理程序
    /// </summary>
    public interface IMediatorHandler
    {
        /// <summary>
        /// 发送指令
        /// </summary>
        public Task SendCommand<T>(T command) where T : AbstractCommand;
    }
}