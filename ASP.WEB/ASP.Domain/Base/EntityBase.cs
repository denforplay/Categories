using System.ComponentModel.DataAnnotations;

namespace ASP.Domain.Base
{
    public interface IEntityBase<TKey>
    {
        [Key]
        TKey Id { get; set; }
    }

    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
