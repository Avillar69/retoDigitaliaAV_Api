using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using retoDigitaliaAV_Api.Models.Encuesta;
using retoDigitaliaAV_Api.Repository.Contracts;
using System.IdentityModel.Tokens.Jwt;

namespace retoDigitaliaAV_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly IEncuestaRepository _repository;
        private readonly IEncuestaOpcionRepository _OpcionesRepository;
        private readonly IVotacionRepository _VotacionRepository;

        public EncuestaController(IEncuestaRepository repository, IEncuestaOpcionRepository OpcionesRepository, IVotacionRepository votacionRepository)
        {
            _repository = repository;
            _OpcionesRepository = OpcionesRepository;
            _VotacionRepository = votacionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EncuestaModel>>> Get()
        {
            var encuestas = await _repository.GetAllAsync();
            return Ok(encuestas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EncuestaModel>> Get(int id)
        {
            try
            {
                var encuesta = await _repository.GetByIdAsync(id);
                encuesta.Opciones = await _OpcionesRepository.GetOpcionesById(id);

                if (encuesta == null)
                {
                    return NotFound();
                }
                return Ok(encuesta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EncuestaModel encuesta)
        {
            await _repository.AddAsync(encuesta);
            return CreatedAtAction(nameof(Get), new { id = encuesta.idEncuesta }, encuesta);
        }
        [HttpPost("Voto")]
        public async Task<ActionResult> Voto([FromBody] VotacionModel voto)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;
            voto.idUsuario = userId.ToString();
            await _VotacionRepository.AddAsync(voto);
            return CreatedAtAction(nameof(Get), new { id = voto.idVotacion }, voto);
        }


        [HttpGet("GetResultados/{id}")]
        public async Task<ActionResult<EncuestaModel>> GetResultados(int id)
        {
            try
            {
                var encuesta = await _repository.GetByIdAsync(id);
                encuesta.Opciones = await _OpcionesRepository.GetOpcionesById(id);
                foreach (var item in encuesta.Opciones)
                {
                    var votos = await _VotacionRepository.GetVotacionById(item.idOpcion);
                    item.Votos = votos;
                    item.conteo = votos.Count;
                }

                if (encuesta == null)
                {
                    return NotFound();
                }
                return Ok(encuesta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EncuestaModel encuesta)
        {
            if (id != encuesta.idEncuesta)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(encuesta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
