using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.SymbolStore;
using System.Text;
using WebApiApp.Data;
using WebApiApp.Models;
using WebApiApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});

builder.Services.AddCors(option => option.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var SecretKey = builder.Configuration["AppSetting:SecretKey"];
var SecretKeyByte = Encoding.UTF8.GetBytes(SecretKey);

builder.Services.AddAuthentication().AddJwtBearer(
    opt =>
    {
        // It,would be ture by default,don't set it to flase
        opt.MapInboundClaims = false;
        // check the handler when you debug
        var tokenhandler = opt.TokenHandlers;
       

        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            //tự cấp token
            ValidateIssuer = false,
            ValidateAudience = false,

            //ký vào token
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(SecretKeyByte),

            ClockSkew = TimeSpan.Zero
        };
        

    });

builder.Services.AddScoped<ILoaiRepository, LoaiRepository>();
builder.Services.AddScoped<ILoaiRepository, LoaiRepositoryInMemory>();
builder.Services.AddScoped<IHangHoaRepository, HangHoaRepository>();

builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSetting"));
var app = builder.Build();

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

app.Run();
