using System.ComponentModel.DataAnnotations;

namespace SGEC.Shared.Entities
{
    public class Contrato
    {
        [Key]
        public int ContratoId { get; set; }

        [Required]
        [StringLength(50)]
        public string? NumeroContrato { get; set; }
        public DateTime FechaContrato { get; set; }

        [StringLength(50)]
        public string? Proveedor { get; set; }
        public decimal MontoTotal { get; set; }
        public ICollection<Computador> computadores { get; set; }
    }
}