using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }
        // Outros campos do fornecedor
        public List<Product> Products { get; set; } = new List<Product>();
    }

}
