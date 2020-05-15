using Blog.Core.Repositories.Permission.Inputs;

namespace Blog.Core.Repositories.Permission
{
    public interface IPermissionRepository : IBaseRepository<PermissionInput>
    {
        void Update(PermissionInput entity);
    }
}
