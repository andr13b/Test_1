using Test_1.Models;
using Test_1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(
    "plugins.json",
    optional: true,
    reloadOnChange: true);

// factory creation
builder.Services
    .AddTransient<IPictureEditorService, PictureEditorService>()
    .AddSingleton<Func<IPictureEditorService>>(x =>
        () => x.GetService<IPictureEditorService>() ?? throw new InvalidOperationException());

// defaults below
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();