using Blog.Core.Repositories.Module.Inputs;

namespace Blog.Core.Repositories.Module
{
    public interface IModuleRepository : IBaseRepository<ModuleInput>
    {
        void Update(ModuleInput entity);
    }
}
