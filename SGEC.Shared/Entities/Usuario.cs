using System.ComponentModel.DataAnnotations;

namespace SGEC.Shared.Entities
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int OficinaId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        [Required]
        public Oficina oficinas { get; set; }
        [Required]
        public ICollection<ActaEntrega> actasentregas { get; set; }
    }
}