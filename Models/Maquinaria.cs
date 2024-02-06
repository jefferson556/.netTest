using System.ComponentModel.DataAnnotations;

namespace WebAppTest.Models
{
    public class Maquinaria
    {
        [Key]
        public int MaquinariaId { get; set; }

      
        [StringLength(50)]
        public string Serie { get; set; }

      
        [StringLength(255)]
        public string Descripcion { get; set; }
       
        public bool  Estado { get; set; }
    }
}
