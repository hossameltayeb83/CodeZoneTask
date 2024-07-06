using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Features.Items.Query
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
    }
}
