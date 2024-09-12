namespace PedidosAPI.Domain.Entities.Parceiro
{
    public interface IParceiroRepository
    {
        void Adicionar(Parceiro parceiro);
        List<Parceiro> Listar(int pageNumber, int pageQuantity);
        Parceiro ObterPorId(int id);
        bool ExistePorEmail(string email);
        bool ExistePorId(int id);
    }
}
