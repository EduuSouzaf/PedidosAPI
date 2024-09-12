using System;

namespace PedidosAPI.ValueObjects
{
    public class Nome
    {
        public string Valor { get; private set; }

        private const int TamanhoMinimo = 2;
        private const int TamanhoMaximo = 200;

        protected Nome() { }

        public Nome(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("O nome não pode ser nulo ou vazio.");

            if (valor.Length < TamanhoMinimo)
                throw new ArgumentException($"O nome deve ter pelo menos {TamanhoMinimo} caracteres.");

            if (valor.Length > TamanhoMaximo)
                throw new ArgumentException($"O nome deve ter no máximo {TamanhoMaximo} caracteres.");

            Valor = valor;
        }

        public override string ToString() => Valor;

        public override bool Equals(object obj)
        {
            if (obj is Nome otherNome)
                return Valor.Equals(otherNome.Valor, StringComparison.OrdinalIgnoreCase);

            return false;
        }

        public override int GetHashCode() => Valor.ToLower().GetHashCode();
    }
}
