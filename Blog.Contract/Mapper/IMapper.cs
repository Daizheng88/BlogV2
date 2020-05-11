namespace Blog.Contract.Mapper
{
    /// <summary>
    /// 映射器，用于扫描
    /// </summary>
    public interface IMapper
    {
    }

    /// <summary>
    /// 映射器
    /// </summary>
    public interface IMapper<TSource> : IMapper
    {
        /// <summary>
        /// 映射到目标类型
        /// </summary>
        object To<TTarget>(TSource source);
    }
}
