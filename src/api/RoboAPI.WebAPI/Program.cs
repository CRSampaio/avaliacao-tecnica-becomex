using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Diagnostics;
using RoboAPI.Infrastructure;
using RoboAPI.Infrastructure.Persistencia.Configuracao;
using RoboAPI.Services;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
{
    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddBusinessLogicServices();
    builder.Services.AddInfrastructureServices();
}

{
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.Services.CriarRobo();

    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            // Get the exception
            var exception = context.Features.Get<IExceptionHandlerFeature>()!.Error;

            // Create a JSON response
            var errorResponse = new
            {
                Error = "An error occurred while processing your request.",
                exception.Message
            };

            var jsonResponse = JsonSerializer.Serialize(errorResponse);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(jsonResponse);
        });
    });

    app.UseCors(configure =>
    {
        configure
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });

    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}