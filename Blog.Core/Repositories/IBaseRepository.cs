namespace Blog.Core.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// 插入实体
        /// </summary>
        void Insert(TEntity entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        void Delete(TEntity entity);
    }
}
