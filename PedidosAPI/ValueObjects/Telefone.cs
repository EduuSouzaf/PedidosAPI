using System;
using System.Text.RegularExpressions;

namespace PedidosAPI.ValueObjects
{
    public class Telefone
    {
        private static readonly Regex TelefoneRegex = new Regex(
            @"^\+?[1-9][0-9]{7,14}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public string Numero { get; private set; }

        protected Telefone() { }

        public Telefone(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("O número de telefone não pode ser nulo ou vazio.");

            if (!TelefoneRegex.IsMatch(numero))
                throw new ArgumentException("O número de telefone fornecido é inválido.");

            Numero = numero;
        }

        public override string ToString() => Numero;

        public override bool Equals(object obj)
        {
            if (obj is Telefone otherTelefone)
                return Numero.Equals(otherTelefone.Numero, StringComparison.OrdinalIgnoreCase);

            return false;
        }

        public override int GetHashCode() => Numero.GetHashCode();
    }
}
