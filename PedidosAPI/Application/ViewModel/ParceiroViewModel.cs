using PedidosAPI.Enum;
using PedidosAPI.ValueObjects;

namespace PedidosAPI.Application.ViewModel
{
    public class ParceiroViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public EnumStatus Status { get; set; }

        public ParceiroViewModel(string nome, string email, string telefone, EnumStatus status)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Status = status;
        }
    }
}
