using PedidosAPI.Enum;
using PedidosAPI.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidosAPI.Domain.Entities.Parceiro
{
    [Table("parceiro")]
    public class Parceiro
    {
        [Key]
        public int Id { get; set; }
        public NomePessoa Nome { get; set; }
        public Email Email { get; set; }
        public Telefone Telefone { get; set; }
        public EnumStatus Status { get; set; }

        public Parceiro(NomePessoa nome, Email email, Telefone telefone, EnumStatus status)
        {
            this.Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.Email = email;
            this.Telefone = telefone;
            this.Status = status;
        }

        public Parceiro()
        {
        }
    }
}
