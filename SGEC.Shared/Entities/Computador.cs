using System.ComponentModel.DataAnnotations;

namespace SGEC.Shared.Entities
{
    public class Computador
    {
        [Key]
        public int ComputadorId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Modelo { get; set; }
        [StringLength(50)]
        public string? Marca { get; set; }
        [StringLength(50)]
        public string? NumeroSerie { get; set; }
        [StringLength(50)]
        public string? CodigoBien { get; set; }
        [StringLength(50)]
        public string? Estado { get; set; } // Ej: Nueva, Usada, Dada de Baja
        public ICollection<ActaEntrega> actasentregas { get; set; }
        public OrdenCompra ordencompras { get; set; }
        public int OrdenCompraId { get; set; }
        public Contrato contratos { get; set; }
        public int ContratoId { get; set; }
    }
}