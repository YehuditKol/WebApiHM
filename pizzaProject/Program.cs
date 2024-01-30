using ourProject.ourModels.Interfaces;
using ourProject.ourServices;
using ourProject.FileService;
using middlewares.Extensions;
using Microsoft;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ourServices;
using ourModels.Interfaces;
using pizzaProject.Extensions;
using System.Text;


var builder = WebApplication.CreateBuilder(args);





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckleB
builder.Services.AddAuthentication(options =>
{
    // options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.TokenValidationParameters = IdentityService.GetTokenValidationParameters();
});

builder.Services.AddAuthorization(cfg =>
{
   
    cfg.AddPolicy("Admin", policy => policy.RequireClaim("UserType", "Admin"));
    cfg.AddPolicy("SuperWorker", policy => policy.RequireClaim("UserType", "SuperWorker"));

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "core", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter your Task JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { new OpenApiSecurityScheme
                        {
                         Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                    new string[] {}
                }});
});


builder.Services.AddControllers();

builder.Services.AddSingleton<IPizza, PizzaService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddSingleton<Ifile, FileService>();
builder.Services.AddSingleton<ILog, LogService>();
builder.Services.AddScoped<Iidentity, IdentityService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
   
//}


app.UseErrorHandler();
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/api/Errors/error-development");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/api/Errors/error");
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();




app.MapControllers();
app.UseActionLog();

app.Run();
