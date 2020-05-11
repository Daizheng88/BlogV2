namespace Blog.Core.UnitOfWork
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork
    {
        ExecutingProcess SaveChanges();
    }
}
