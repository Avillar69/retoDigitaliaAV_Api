using retoDigitaliaAV_Api.Context;
using retoDigitaliaAV_Api.Models.Encuesta;
using Microsoft.EntityFrameworkCore;
using retoDigitaliaAV_Api.Repository.Contracts;

namespace retoDigitaliaAV_Api.Repository.Implementations
{
    public class EncuestaRepository : IEncuestaRepository
    {
        private readonly ApplicationDbContext _context;

        public EncuestaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EncuestaModel>> GetAllAsync()
        {
            return await _context.Encuesta.ToListAsync();
        }

        public async Task<EncuestaModel> GetByIdAsync(int id)
        {
            return await _context.Encuesta.FindAsync(id);
        }

        public async Task AddAsync(EncuestaModel encuesta)
        {
            await _context.Encuesta.AddAsync(encuesta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EncuestaModel encuesta)
        {
            _context.Encuesta.Update(encuesta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var encuesta = await _context.Encuesta.FindAsync(id);
            if (encuesta != null)
            {
                _context.Encuesta.Remove(encuesta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
