using Blog.Core.Repositories.Type.Inputs;

namespace Blog.Core.Repositories.Type
{
    public interface ITypeRepository : IBaseRepository<TypeInput>
    {
        void Update(TypeInput entity);
    }
}
