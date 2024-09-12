using Microsoft.EntityFrameworkCore;
using Zulu.Api.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=cn"));
builder.Services.AddTransient<SeedDb>();

//tres fromas para inyectar servicio
//builder.AddSingleton->  esto  permanece en momoria todo el tiempo
//builder.Services.AddScoped ->cada que lo necesia inyecta un objeto
//builder.Services AddTransient -> inyecta solo una vez y no inyecta nunca mas


var app = builder.Build();

//en program no se puede injectar solo en clases

//creamosun metodo para injectar

SeedData(app);

void SeedData(WebApplication? app)
{
    //creamos una injection en mano
  IServiceScopeFactory? scopeFactory= app.Services.GetService<IServiceScopeFactory>();
    using (IServiceScope? scope = scopeFactory!.CreateScope())
    {
        SeedDb? service= scope.ServiceProvider.GetService<SeedDb>();
        //llamamos metodo SeedAsync que es asycrono con metodo Wait()
        service!.SeedAsync().Wait();
    }
}






if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//agregar  para habilitar las peticiones
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());


app.Run();
