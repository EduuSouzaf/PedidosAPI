using System;
using System.Text.RegularExpressions;

namespace PedidosAPI.ValueObjects
{
    public class Email
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public string Endereco { get; private set; }

        protected Email() { }

        public Email(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("O endereço de e-mail não pode ser nulo ou vazio.");

            if (!EmailRegex.IsMatch(endereco))
                throw new ArgumentException("O endereço de e-mail fornecido é inválido.");

            Endereco = endereco;
        }

        public override string ToString() => Endereco;

        public override bool Equals(object obj)
        {
            if (obj is Email otherEmail)
                return Endereco.Equals(otherEmail.Endereco, StringComparison.OrdinalIgnoreCase);

            return false;
        }

        public override int GetHashCode() => Endereco.ToLower().GetHashCode();
    }
}
