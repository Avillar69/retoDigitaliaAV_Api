using Microsoft.EntityFrameworkCore;
using retoDigitaliaAV_Api.Context;
using retoDigitaliaAV_Api.Models.Encuesta;
using retoDigitaliaAV_Api.Repository.Contracts;

namespace retoDigitaliaAV_Api.Repository.Implementations
{
    public class VotacionRepository : IVotacionRepository
    {
        private readonly ApplicationDbContext _context;

        public VotacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(VotacionModel voto)
        {
            var Opcion = await _context.EncuestaOpcion.FindAsync(voto.idOpcion);
            Opcion.Votos.Add(voto);
            _context.SaveChangesAsync();
        }
        public async Task<List<VotacionModel>> GetVotacionById(int id)
        {
            return await _context.Votacion.Where(oe => oe.idOpcion == id).ToListAsync();
        }

    }
}
