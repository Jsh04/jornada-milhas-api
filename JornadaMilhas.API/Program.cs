using JornadaMilhas.API;
using JornadaMilhas.API.Extensions;
using JornadaMilhas.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddApiConfiguration();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

var app = builder.Build();


// Desactive Cors
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();
app.UseMiddleware<GlobalExceptionHandler>();

app.MapControllers();

await app.RunAsync();