using Microsoft.EntityFrameworkCore;
using SuperMyCadoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<SuperMyCadoContext>(opt => opt.UseSqlite("Data Source = SuperMyCado.db"));

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();