using System;
using PedidosAPI.Enum;

namespace PedidosAPI.ValueObjects
{
    public class TipoPedido
    {
        public EnumTipoPedido Valor { get; private set; }

        protected TipoPedido() { }

        public TipoPedido(EnumTipoPedido valor)
        {
            if (!EhTipoValido(valor))
            {
                throw new ArgumentException("Tipo de pedido inválido.");
            }

            Valor = valor;
        }
        public static TipoPedido CriarDeValor(int valor)
        {
            if (!EhTipoValido((EnumTipoPedido)valor))
            {
                throw new ArgumentException("Tipo de pedido inválido.");
            }

            return new TipoPedido((EnumTipoPedido)valor);
        }

        private static bool EhTipoValido(EnumTipoPedido tipo)
        {
            return tipo == EnumTipoPedido.Compra ||
                   tipo == EnumTipoPedido.Venda;
        }

        public override string ToString() => Valor.ToString();

        public override bool Equals(object obj)
        {
            if (obj is TipoPedido otherTipo)
                return Valor == otherTipo.Valor;

            return false;
        }

        public override int GetHashCode() => Valor.GetHashCode();
    }
}
