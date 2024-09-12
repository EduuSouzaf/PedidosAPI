using System;
using PedidosAPI.Enum;

namespace PedidosAPI.ValueObjects
{
    public class StatusPedido
    {
        public EnumStatusPedido Valor { get; private set; }

        protected StatusPedido() { }

        public StatusPedido(EnumStatusPedido valor)
        {
            if (!EhStatusValido(valor))
            {
                throw new ArgumentException("Status de pedido inválido.");
            }

            Valor = valor;
        }

        public static StatusPedido CriarDeValor(int valor)
        {
            if (!EhStatusValido((EnumStatusPedido)valor))
            {
                throw new ArgumentException("Status de pedido inválido.");
            }

            return new StatusPedido((EnumStatusPedido)valor);
        }

        private static bool EhStatusValido(EnumStatusPedido status)
        {
            return status == EnumStatusPedido.Aberto ||
                   status == EnumStatusPedido.Fechado ||
                   status == EnumStatusPedido.Cancelado;
        }

        public override string ToString() => Valor.ToString();

        public override bool Equals(object obj)
        {
            if (obj is StatusPedido otherStatus)
                return Valor == otherStatus.Valor;

            return false;
        }

        public override int GetHashCode() => Valor.GetHashCode();
    }
}
