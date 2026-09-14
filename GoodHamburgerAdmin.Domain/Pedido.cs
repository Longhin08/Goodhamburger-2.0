using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHamburgerAdmin.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pendente";
        public List<PedidoItem> Itens { get; set; } = new();
    }

    public class PedidoItem
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ItemId { get; set; }
        public Item? Item { get; set; }
        public int Quantidade { get; set; }
    }
}
