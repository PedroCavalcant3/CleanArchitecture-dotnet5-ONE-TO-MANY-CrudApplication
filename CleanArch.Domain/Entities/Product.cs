using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities {
    public class Product {

        public int Id {get; set;}
        public string Name { get; set;}
        public string Description { get; set;}
        public decimal Price { get; set; }

        // Chave estrangeira para Supplier
        public int? SupplierId { get; set; }

        // Propriedade de navegação para Supplier
        public Supplier Supplier { get; set; }
    }
}
