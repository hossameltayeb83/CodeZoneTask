using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Features.Stores.Command.UpdateStore
{
    public class UpdateStoreCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
