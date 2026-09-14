using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHamburgerAdmin.Domain
{
    public class Item
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Categoria { get; set; } = string.Empty;
    }
}
