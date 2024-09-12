using PedidosAPI.Enum;
using PedidosAPI.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidosAPI.Domain.Entities.Pedido
{
    [Table("pedido")]
    public class Pedido
    {
        public Pedido(int idParceiro, EnumTipoPedido tipoPedido, EnumStatusPedido status, double totalpedido)
        {
            IdParceiro = idParceiro;
            TipoPedido = tipoPedido;
            Status = status;
            Totalpedido = totalpedido;
        }

        [Key]
        public int Id { get; set; }
        public int IdParceiro { get; set; }
        public EnumTipoPedido TipoPedido { get; set; }
        public EnumStatusPedido Status { get; set; }
        public double Totalpedido { get; set; }

        public List<ProdutoPedido> Itens { get; set; }

        protected Pedido() { }

    }
}
