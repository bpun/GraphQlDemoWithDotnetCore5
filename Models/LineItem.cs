using System.ComponentModel.DataAnnotations;

namespace GraphDemo.Models
{
    public class LineItem
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
