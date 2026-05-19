using BusinessLogic.Classes;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MmoContext>(options =>
{
    
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactToConnect", policy =>
    {
        policy.WithOrigins(builder.Configuration["AllowedOrigins"] ?? "http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();

// Auto apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MmoContext>();
    await db.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
//We want these pages to always be visible
app.MapScalarApiReference();
app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
});

app.UseHttpsRedirection();

app.UseCors("AllowReactToConnect");

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
