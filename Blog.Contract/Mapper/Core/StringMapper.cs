namespace Blog.Contract.Mapper.Core
{
    public class StringMapper : IMapper<string>
    {
        public object To<TTarget>(string source)
        {
            return source;
        }
    }
}
