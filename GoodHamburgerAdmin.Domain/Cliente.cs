using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHamburgerAdmin.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

}
