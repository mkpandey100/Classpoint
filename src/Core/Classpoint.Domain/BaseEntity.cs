using System.ComponentModel.DataAnnotations;

namespace ClassPoint.Domain
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}