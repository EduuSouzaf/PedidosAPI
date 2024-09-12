using PedidosAPI.Domain.Entities.Parceiro;

namespace PedidosAPI.Infrastructure.Repositories
{
    public class ParceiroRepository : IParceiroRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Adicionar(Parceiro parceiro)
        {
            _context.Parceiros.Add(parceiro);
            _context.SaveChanges();
        }

        public List<Parceiro> Listar(int pageNumber, int pageQuantity)
        {
            return _context.Parceiros.Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
        }

        public Parceiro ObterPorId(int id)
        {
            return _context.Parceiros.Find(id);
        }

        public bool ExistePorEmail(string email)
        {
            return _context.Parceiros.Any(p => p.Email.Endereco == email);
        }

        public bool ExistePorId(int id)
        {
            return _context.Parceiros.Any(p => p.Id == id);
        }
    }
}
