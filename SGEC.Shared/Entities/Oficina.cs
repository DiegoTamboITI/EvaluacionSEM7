using System.ComponentModel.DataAnnotations;

namespace SGEC.Shared.Entities
{
    public class Oficina
    {
        [Key]
        public int OficinaId { get; set; }

        [Required]
        [StringLength(50)]
        public string? NombreOficina { get; set; }

        [StringLength(50)]
        public string? Ubicacion { get; set; }
        [Required]
        public ICollection<Usuario> usuarios { get; set; }
        [Required]
        public ICollection<ActaEntrega> actasentregas { get; set; }
    }
}