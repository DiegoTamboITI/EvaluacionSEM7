using System.ComponentModel.DataAnnotations;

namespace SGEC.Shared.Entities
{
    public class OrdenCompra
    {
        [Key]
        public int OrdenCompraId { get; set; }

        [Required]
        [StringLength(50)]
        public string? NumeroCompra { get; set; }
        public DateTime FechaOrden { get; set; }

        [StringLength(50)]
        public string? Proveedor { get; set; }
        public decimal MontoTotal { get; set; }
        public ICollection<Computador> computadores { get; set; }

    }
}