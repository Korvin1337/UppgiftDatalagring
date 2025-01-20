

using Business.Interfaces;
using Business.Services;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\projects\EC2\C#\UppgiftDatalagring\Data\Databases\local_database.mdf;Integrated Security=True;Connect Timeout=30"));
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
