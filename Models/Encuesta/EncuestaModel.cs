using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace retoDigitaliaAV_Api.Models.Encuesta
{
    public class EncuestaModel
    {
        [Key]
        public int idEncuesta { get; set; }
        public string NombreEncuesta { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public List<EncuestaOpcionModel> Opciones { get; set; } = new List<EncuestaOpcionModel>();
    }
    public class EncuestaOpcionModel
    {
        [Key]
        public int idOpcion { get; set; }
        public int idEncuesta { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        [NotMapped]
        public int conteo { get; set; }
        public List<VotacionModel> Votos { get; set; } = new List<VotacionModel>();
        public EncuestaModel Encuesta { get; set; } = new EncuestaModel();
    }
    public class VotacionModel
    {
        [Key]
        public int idVotacion { get; set; }
        public int idEncuesta { get; set; }
        public int idOpcion { get; set; }
        public string idUsuario { get; set; } = string.Empty;
        public EncuestaOpcionModel EncuestaOpcion { get; set; } = new EncuestaOpcionModel();
    }
}
