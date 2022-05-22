using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CodeService.Data;
using CodeService.Services;
using CodeService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CodeServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CodeServiceContext") ?? throw new InvalidOperationException("Connection string 'CodeServiceContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICodeRunningService,CodeRunningService>();
builder.Services.AddScoped<IFileManagementService,FileManagementService>();
builder.Services.AddScoped<IProgrammingLanguagesService,ProgrammingLanguagesService>();
builder.Services.AddCors();


var app = builder.Build();

using (var context = builder.Services.BuildServiceProvider().GetRequiredService<CodeServiceContext>())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    //context.Add(new CodeQuestion() { Id = Guid.NewGuid() });
    var python = new ProgrammingLanguage() { Id = Guid.NewGuid(), Command = "python", FileExtension = ".py", Name = "Python" };
    context.Add(python);
    var js = new ProgrammingLanguage() { Id = Guid.NewGuid(), Command = "node", FileExtension = ".js", Name = "Javascript" };
    context.Add(js);
    var qt = new CodeQuestion() { Id = Guid.NewGuid() };
    context.Add(qt);
    var qtskelet = new QuestionSkeleton() {Id = Guid.NewGuid(),Code="def sum(a,b)\n\t#your code here\n\nprint(sum(1,2))",ProgrammingLanguageId = python.Id,CodeQuestionId=qt.Id};
    context.Add(qtskelet);
    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));/**/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
