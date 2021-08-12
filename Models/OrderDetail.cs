using System.ComponentModel.DataAnnotations;

namespace GraphDemo.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(128)]
        public string ReceiverName { get; set; }
        [MaxLength(256)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string ContactNo { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
