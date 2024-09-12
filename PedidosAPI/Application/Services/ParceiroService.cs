using PedidosAPI.Domain.Entities.Parceiro;

namespace PedidosAPI.Application.Services
{
    public class ParceiroService
    {
        private readonly IParceiroRepository _parceiroRepository;

        public ParceiroService(IParceiroRepository parceiroRepository)
        {
            _parceiroRepository = parceiroRepository;
        }

        public bool VerificarSeParceiroExiste(int id)
        {
            return _parceiroRepository.ExistePorId(id);
        }
    }
}
