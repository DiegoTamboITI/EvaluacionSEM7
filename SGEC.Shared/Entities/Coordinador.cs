using System.ComponentModel.DataAnnotations;

namespace SGEC.Shared.Entities
{
    public class Coordinador
    {
        [Key]
        public int CoordinadorId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
    }
}