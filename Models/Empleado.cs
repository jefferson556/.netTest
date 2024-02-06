using System.ComponentModel.DataAnnotations;

namespace WebAppTest.Models
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }

    
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Cargo { get; set; }

        [StringLength(20)]
        public string Cedula { get; set; }

        [StringLength(50)]
        public string Area { get; set; }

        public virtual ICollection<Asignacion> Asignaciones { get; set; }

    }
}
