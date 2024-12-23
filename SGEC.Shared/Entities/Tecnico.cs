using System.ComponentModel.DataAnnotations;

namespace SGEC.Shared.Entities
{
    public class Tecnico
    {
        [Key]
        public int TecnicoId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }

        [StringLength(50)]
        public string? Apellido { get; set; }
        public bool EsAdministrador { get; set; }
        public ICollection<ActaEntrega> actasentregas { get; set; }
        public ICollection<HistorialAdministrador> historialadministradores { get; set; }

    }
}