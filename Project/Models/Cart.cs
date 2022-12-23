using System;

namespace Project.Models
{
    public class Cart
    {
        public long ID { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int Aantal { get; set; }

     

        public virtual Product Product { get; set; }
    }
}
