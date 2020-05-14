namespace Blog.Core.Repositories.Modules.Inputs
{
    public class ModuleInput : Entity
    {
        /// <summary>
        /// 模块信息
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否菜单
        /// </summary>
        public int IsMenu { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        public int MenuNo { get; set; }
    }
}
