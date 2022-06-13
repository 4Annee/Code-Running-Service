using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CodeService.Data;
using CodeService.Services;
using CodeService.Models;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CodeServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CodeServiceContext") ?? throw new InvalidOperationException("Connection string 'CodeServiceContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDiscoveryClient();

builder.Services.AddScoped<ICodeRunningService,CodeRunningService>();
builder.Services.AddScoped<IFileManagementService,FileManagementService>();
builder.Services.AddScoped<IProgrammingLanguagesService,ProgrammingLanguagesService>();
builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:7777"));/**/

app.UseDiscoveryClient();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
