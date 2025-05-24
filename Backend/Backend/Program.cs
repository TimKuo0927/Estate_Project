using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MaindbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Maindb")));

builder.Services.AddScoped<EmployeeService>();

builder.Services.AddScoped<EstateService>();

builder.Services.AddScoped<JwtService>();

builder.Services.AddScoped<UserService>();

//Add CORS policy before Build()
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "https://localhost:5173") // <== your frontend origins
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

//add Jwt authorize 
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var jwtIssuer = jwtSettings["Issuer"];
var jwtKey = jwtSettings["Key"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
