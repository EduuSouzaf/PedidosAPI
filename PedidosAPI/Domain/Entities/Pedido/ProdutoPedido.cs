using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PedidosAPI.Domain.Entities.Pedido
{
    [Table("produtoPedido")]
    public class ProdutoPedido
    {
        [Key]
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public bool Status { get; set; }

        public ProdutoPedido(int idPedido, int idProduto, string nome, int quantidade, double valor, bool status)
        {
            this.IdPedido = idPedido;
            this.IdProduto = idProduto;
            this.Nome = nome;
            this.Quantidade = quantidade;
            this.Valor = valor;
            this.Status = status;
        }
    }
}
