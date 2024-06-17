using retoDigitaliaAV_Api.Models.Encuesta;

namespace retoDigitaliaAV_Api.Repository.Contracts
{
    public interface IEncuestaRepository
    {
        Task<IEnumerable<EncuestaModel>> GetAllAsync();
        Task<EncuestaModel> GetByIdAsync(int id);
        Task AddAsync(EncuestaModel encuesta);
        Task UpdateAsync(EncuestaModel encuesta);
        Task DeleteAsync(int id);
    }
}
