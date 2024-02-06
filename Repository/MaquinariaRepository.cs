using Microsoft.EntityFrameworkCore;
using WebAppTest.Models;

namespace WebAppTest.Repository
{
    public class MaquinariaRepository : IRepository<Maquinaria>
    {

        private StoreContext _storeContext;

        public MaquinariaRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task Add(Maquinaria maquinariaInsertDto) =>
         await _storeContext.Maquinarias.AddAsync(maquinariaInsertDto);

        public void Delete(Maquinaria entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Maquinaria>> Get()
        => await _storeContext.Maquinarias.ToListAsync();

        public async Task<Maquinaria> GetById(int id)
        => await _storeContext.Maquinarias.FindAsync(id);

        public async Task Save()
        => await _storeContext.SaveChangesAsync();

        public void Update(Maquinaria maquinaria)
        {
            _storeContext.Maquinarias.Attach(maquinaria);  
            _storeContext.Entry(maquinaria).State = EntityState.Modified;  
        }

    }
}
