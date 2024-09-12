using PedidosAPI.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidosAPI.Domain.Entities.Produto
{
    [Table("produto")]
    public class Produto
    {
        public Produto(string nome, int quantidade, double preco)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Quantidade = quantidade;
            Preco = preco;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
    }
}
