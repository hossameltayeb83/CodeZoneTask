using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Domain.Entities
{
    public class StoreItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int StoreId { get; set; }
        public Store store { get; set; }
        public int Quantity { get; set; }
    }
}
