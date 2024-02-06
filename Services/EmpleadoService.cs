using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using WebAppTest.DTOs;
using WebAppTest.Models;
using WebAppTest.Repository;

namespace WebAppTest.Services
{
    public class EmpleadoService : ICommonService<EmpleadoDto, EmpleadoInsertDto, EmpleadoUpdateDto>
    {
        private readonly StoreContext _storeContext;
        private readonly IRepository<Empleado> _empleadoRepository;

        public EmpleadoService(StoreContext storeContext, IRepository<Empleado> empleadoRepository)
        {
            _storeContext = storeContext;
            _empleadoRepository = empleadoRepository;
        }

        public async Task<EmpleadoDto> Add(EmpleadoInsertDto empleadoInsertDto)
        {
            var empleado = new Empleado
            {
                Nombre = empleadoInsertDto.Nombre,
                Cargo = empleadoInsertDto.Cargo,
                Cedula = empleadoInsertDto.Cedula,
                Area = empleadoInsertDto.Area
            };

            await _empleadoRepository.Add(empleado);
            await _empleadoRepository.Save();

            return new EmpleadoDto
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Cargo = empleado.Cargo,
                Cedula = empleado.Cedula,
                Area = empleado.Area
            };
        }

        public async Task<EmpleadoDto> Delete(int id)
        {
            var empleado = await _storeContext.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _storeContext.Empleados.Remove(empleado);
                await _storeContext.SaveChangesAsync();

              
            }
            return null;  
        }

        public async Task<IEnumerable<EmpleadoDto>> Get()
        {
            var empleados = await _empleadoRepository.Get(); // Espera la operación asíncrona aquí
            return empleados.Select(e => new EmpleadoDto
            {
                EmpleadoId = e.EmpleadoId,
                Nombre = e.Nombre,
                Cargo = e.Cargo,
                Cedula = e.Cedula,
                Area = e.Area
               
            }).ToList();  
        }

        public async Task<EmpleadoDto> GetById(int id)
        {
            var empleado = await _empleadoRepository.GetById(id);
            if (empleado != null)
            {
                return new EmpleadoDto
                {
                    EmpleadoId = empleado.EmpleadoId,
                    Nombre = empleado.Nombre,
                    Cargo = empleado.Cargo,
                    Cedula = empleado.Cedula,
                    Area = empleado.Area
                
                };
            }
            return null;
        }

        public async Task<EmpleadoDto> Update(int id, EmpleadoUpdateDto empleadoUpdateDto)
        {
            var empleado = await _storeContext.Empleados.FindAsync(id);
            if (empleado != null)
            {
                empleado.Nombre = empleadoUpdateDto.Nombre;
                empleado.Cargo = empleadoUpdateDto.Cargo;
                empleado.Cedula = empleadoUpdateDto.Cedula;
                empleado.Area = empleadoUpdateDto.Area;
                

                await _storeContext.SaveChangesAsync();

                return new EmpleadoDto
                {
                    EmpleadoId = empleado.EmpleadoId,
                    Nombre = empleado.Nombre,
                    Cargo = empleado.Cargo,
                    Cedula = empleado.Cedula,
                    Area = empleado.Area
                   
                };
            }
            return null;
        }
    }
}
