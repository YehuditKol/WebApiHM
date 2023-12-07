using ourProject.ourModels.Interfaces;
using ourProject.ourServices;
using ourProject.FileService;
using middlewares.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ourServices;

// using ourProject.pizzaProject.Extensions;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckleB
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPizza, PizzaService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddSingleton<Ifile, FileService>();
builder.Services.AddSingleton<ILog, LogService>();
// builder.Services.AddAuthentication(options =>
//     {
//         options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//     }).AddJwtBearer(cfg =>
//         {
//         cfg.RequireHttpsMetadata = false;
//         cfg.TokenValidationParameters = AuthenticationService.GetTokenValidationParameters();
//          });


   builder.Services.AddAuthorization(cfg =>
    {
        cfg.AddPolicy("Admin", policy => policy.RequireClaim("type", "Admin"));
        cfg.AddPolicy("SuperWorker", policy => policy.RequireClaim("type", "SuperWorker"));
        cfg.AddPolicy("ClearanceLevel1", policy => policy.RequireClaim("ClearanceLevel", "1", "2"));
        cfg.AddPolicy("ClearanceLevel2", policy => policy.RequireClaim("ClearanceLevel", "2"));
    });




var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();




app.MapControllers();
app.UseActionLog();

app.Run();
