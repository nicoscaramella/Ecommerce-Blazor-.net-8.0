using Ecommerce.repositorio.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Ecommerce.repositorio.Contrato;

using Ecommerce.repositorio.Implementacion;
using Ecommerce.utilidades;

using Ecommerce.servicio.Contrato;
using Ecommerce.servicio.Implementacion;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DbecommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});


builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();

builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();

builder.Services.AddScoped<IProductoServicio, ProductoServicio>();

builder.Services.AddScoped<IVentaServicio, VentaServicio>();

builder.Services.AddScoped<IDashboardService, DashboardServicio>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica",
        app =>
        {
            app.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }
    );
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
