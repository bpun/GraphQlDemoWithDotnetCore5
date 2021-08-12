using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace GraphDemo.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderedDate { get; set; }
        [MaxLength(128)]
        public string DeliveredStatus { get; set; }
        public DateTime DeliveredDate { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; } = new List<LineItem>();
    }
}
