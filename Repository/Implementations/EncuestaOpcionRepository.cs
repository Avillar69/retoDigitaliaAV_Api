using Microsoft.EntityFrameworkCore;
using retoDigitaliaAV_Api.Context;
using retoDigitaliaAV_Api.Models.Encuesta;
using retoDigitaliaAV_Api.Repository.Contracts;

namespace retoDigitaliaAV_Api.Repository.Implementations
{
    public class EncuestaOpcionRepository : IEncuestaOpcionRepository
    {
        private readonly ApplicationDbContext _context;
        public EncuestaOpcionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EncuestaOpcionModel>> GetAllAsync()
        {
            return await _context.EncuestaOpcion.ToListAsync();
        }
        public async Task<List<EncuestaOpcionModel>> GetOpcionesById(int id)
        {
            return await _context.EncuestaOpcion.Where(oe => oe.idEncuesta == id).ToListAsync();
        }

    }
}
