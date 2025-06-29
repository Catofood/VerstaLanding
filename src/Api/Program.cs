using Api.Middleware;
using Application;
using Application.Common;
using Application.Settings;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowFrontend", policy =>
        {
            policy.WithOrigins("http://localhost:5173") // фронтенд в dev
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.Configure<InputLimitSettings>(builder.Configuration.GetSection("InputLimitSettings"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowFrontend");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

// app.UseAuthorization();

app.MapControllers();

app.Run();