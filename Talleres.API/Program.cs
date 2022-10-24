using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Talleres.API;
using Talleres.API.Repository;
using Talleres.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITallerParticipanteRepository, TallerParticipanteRepository>();
builder.Services.AddScoped<IHorarioRepository, HorarioRepositoy>();
builder.Services.AddScoped<ITallerRepository, TallerRepository>();
builder.Services.AddScoped<ITallerProgramacionRepository, TallerProgramacionRepository>();
builder.Services.AddScoped<IPublicoRepository, PublicoRepository>();
builder.Services.AddScoped<IPatrocinadorRepository, PatrocinadorRepository>();

builder.Services.AddDbContext<TallerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
