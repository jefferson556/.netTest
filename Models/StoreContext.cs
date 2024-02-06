
using Microsoft.EntityFrameworkCore;

namespace WebAppTest.Models
{
    public class StoreContext:DbContext
    {
    
        public StoreContext(DbContextOptions<StoreContext> options):base(options) { }
        
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Maquinaria> Maquinarias { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }



    }
}
