using Blog.Core.Repositories.Role.Inputs;

namespace Blog.Core.Repositories.Role
{
    public interface IRoleRepository : IBaseRepository<RoleInput>
    {
        void Update(RoleInput entity);
    }
}
