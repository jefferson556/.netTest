using WebAppTest.Models;
using Microsoft.EntityFrameworkCore;
 

namespace WebAppTest.Repository
{
    public class EmpleadoRepository : IRepository<Empleado>
    {
        private readonly StoreContext _storeContext;

        public EmpleadoRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        // Obtiene todos los empleados
        public async Task<IEnumerable<Empleado>> Get() =>
            await _storeContext.Empleados.ToListAsync();

        // Obtiene un empleado por su ID
        public async Task<Empleado> GetById(int id) =>
            await _storeContext.Empleados.FindAsync(id);

        // Añade un nuevo empleado
        public async Task Add(Empleado empleado) =>
            await _storeContext.Empleados.AddAsync(empleado);

        // Actualiza un empleado existente
        public void Update(Empleado empleado)
        {
            _storeContext.Empleados.Attach(empleado);
            _storeContext.Entry(empleado).State = EntityState.Modified;
        }

        // Elimina un empleado
        public void Delete(Empleado empleado)
        {
            _storeContext.Empleados.Remove(empleado);
        }

        // Guarda los cambios en la base de datos
        public async Task Save() => await _storeContext.SaveChangesAsync();
    }
}
