using DevIO.Api.Core.Bindings;
using DevIO.Api.Core.IoC;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

configuration.InjectAppSettingsBindings();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.InjectDependencies();

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