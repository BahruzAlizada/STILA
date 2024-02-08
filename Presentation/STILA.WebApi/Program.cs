using STILA.Persistence.Registration;
using STILA.Infrastructure.Registration;
using STILA.Application.Mappers.AutoMapper;

var builder = WebApplication.CreateBuilder(args);
  
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistencesServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddAutoMapper(typeof(DtoMapper));

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
