using System.ComponentModel.DataAnnotations;

namespace SGEC.Shared.Entities
{
    public class HistorialAdministrador
    {
        [Key]
        public int HistorialAdministradorId { get; set; }
        public int TecnicoId { get; set; } // FK
        public Tecnico tecnicos { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}