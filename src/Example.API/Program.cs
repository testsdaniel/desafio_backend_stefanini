using Example.Application.CityService.Service;
using Example.Application.Common;
using Example.Application.ExampleService.Service;
using Example.Application.PersonService.Service;
using Example.Infra.Data;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IExampleService, ExampleService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddDbContext<ExampleContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<BaseService<object>>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ExampleContext>();
    dataContext.Database.Migrate();
}

app.UseCors(options => options.AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();

