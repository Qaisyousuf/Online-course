using System.ComponentModel.DataAnnotations;
namespace Model
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }

    }
}
