using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppTest.DTOs;

namespace WebAppTest.Services
{
    public interface ICommonService<T, TI, TU>
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> Get();
        Task<EmpleadoDto> Add(TI empleadoInsertDto);

        Task<EmpleadoDto> Update(int id, TU empleadoUpdateDto);

        Task<EmpleadoDto> Delete(int id);


    }
}
