
using SEARCHAPI.BackEnd.Services;
using SEARCHAPI.BackEnd.Repositories;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy("AllowFrontEnd",
    policy =>  policy.WithOrigins("http://localhost:3000")
          .AllowAnyMethod()
          .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rewards API", Version = "v1" });
});
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IRewardsRepository, RewardsRepository>();
builder.Services.AddScoped<IRewardsService, RewardsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rewards API v1"));
}

app.UseCors("AllowFrontEnd");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();