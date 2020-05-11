using Blog.Core.Repositories.User.Inputs;

namespace Blog.Core.Repositories.User
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public interface IUserRepository : IBaseRepository<UserInput>
    {
        /// <summary>
        /// 更新登录信息
        /// </summary>
        void UpdateLoginInfo(UserInput entity);

        /// <summary>
        /// 更新名称
        /// </summary>
        void UpdateName(UserInput entity);

        /// <summary>
        /// 更新密码
        /// </summary>
        void UpdatePassword(UserInput entity);
    }
}
