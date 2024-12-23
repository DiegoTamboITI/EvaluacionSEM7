using System.ComponentModel.DataAnnotations;

namespace SGEC.Shared.Entities
{
    public class ActaEntrega
    {
        [Key]
        public int ActaEntregaId { get; set; }
        [Required]
        public Computador ComputadorId { get; set; }
        public int UsuarioId { get; set; } // FK
        [Required]
        public Usuario usuarios { get; set; }
        public int OficinaId { get; set; } // FK
        [Required]
        public Oficina oficinas { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int TecnicoId { get; set; } // FK
        public Computador computadores { get; set; }
        [Required]
        public Tecnico tecnicos { get; set; }
    }
}