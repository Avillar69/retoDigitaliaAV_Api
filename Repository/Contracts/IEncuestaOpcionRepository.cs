using retoDigitaliaAV_Api.Models.Encuesta;

namespace retoDigitaliaAV_Api.Repository.Contracts
{
    public interface IEncuestaOpcionRepository
    {
        Task<IEnumerable<EncuestaOpcionModel>> GetAllAsync();
        Task<List<EncuestaOpcionModel>> GetOpcionesById(int id);
    }
}
