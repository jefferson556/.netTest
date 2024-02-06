using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppTest.Models
{
    public class Asignacion
    {
        [Key]
        public int AsignacionId { get; set; }

        [ForeignKey("Empleado")]
        public int EmpleadoId { get; set; }

        [ForeignKey("Maquinaria")]
        public int MaquinariaId { get; set; }

        public DateTime FechaAsignacion { get; set; }

    
        public virtual Empleado Empleado { get; set; }
        public virtual Empleado Maquinaria { get; set; }
    }
}
