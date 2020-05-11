using Blog.Contract.Infrastructure;
using System;

namespace Blog.Core.Repositories
{
    public class Entity
    {
        public Guid Id { get; set; }

        public Guid Creator { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid? Modifier { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int IsDeleted { get; set; } = DbBoolean.False;
    }
}
