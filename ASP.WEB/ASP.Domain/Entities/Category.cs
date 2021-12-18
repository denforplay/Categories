using ASP.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace ASP.Domain.Entities
{
    public class Category : EntityBase<int>
    {
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
