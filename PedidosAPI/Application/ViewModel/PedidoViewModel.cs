using PedidosAPI.Enum;

namespace PedidosAPI.Application.ViewModel
{
    public class PedidoViewModel
    {
        public PedidoViewModel(int idParceiro, EnumTipoPedido tipoPedido, EnumStatusPedido status, double totalPedido)
        {
            this.IdParceiro = idParceiro;
            this.TipoPedido = tipoPedido;
            this.Status = status;
            this.TotalPedido = totalPedido;
        }

        public int IdParceiro { get; set; }
        public EnumTipoPedido TipoPedido { get; set; }
        public EnumStatusPedido Status { get; set; }
        public double TotalPedido { get; set; }
    }
}
