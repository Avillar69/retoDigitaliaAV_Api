using retoDigitaliaAV_Api.Models.Encuesta;

namespace retoDigitaliaAV_Api.Repository.Contracts
{
    public interface IVotacionRepository
    {
        Task AddAsync(VotacionModel voto);
        Task<List<VotacionModel>> GetVotacionById(int id);
    }
}
