using WebAppTest.Models;
using Microsoft.EntityFrameworkCore;
 
using WebAppTest.Repository;
using WebAppTest.DTOs;
using WebAppTest.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRepository<Empleado>,EmpleadoRepository >();
builder.Services.AddScoped<IRepository<Maquinaria>, MaquinariaRepository>();
 
builder.Services.AddKeyedScoped<ICommonService<EmpleadoDto, EmpleadoInsertDto, EmpleadoUpdateDto>, EmpleadoService>("empleadoService");

// Add services to the container.
builder.Services.AddDbContext<StoreContext>(options =>
{

    options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection"));
    
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
