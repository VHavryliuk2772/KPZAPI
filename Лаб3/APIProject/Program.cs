using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain.RepositoryInterfaces;
using Persistence.Repositories;
using Services.Interfaces;
using Services;
using Services.Mappers;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Services.Helpers;
using AutoMapper;
using InProduct.Middlewares;
using Persistance;
using DateOnlyTimeOnly.AspNet.Converters;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("MSSQLDBConnectionString");
builder.Services.AddDbContext<ApplicationContext>(x => x.UseLazyLoadingProxies().UseSqlServer(connection));
builder.Services.AddCors(o => o.AddPolicy("DevCorsPolicy", builder => 
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
}));
builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    { 
        options.RequireHttpsMetadata = false; 
        options.TokenValidationParameters = new TokenValidationParameters 
        { 
            ValidateIssuer = true, 
            ValidIssuer = AuthOptions.ISSUER, 
            ValidateAudience = true, 
            ValidAudience = AuthOptions.AUDIENCE, 
            ValidateLifetime = true, 
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthOptions.KEY)), 
            ValidateIssuerSigningKey = true,
        }; 
    });

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IManyToManyRepository<>), typeof(ManyToManyRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();


builder.Services.AddControllers(options =>
{
    options.UseDateOnlyTimeOnlyStringConverters();
})
    .AddJsonOptions(options =>
    {
        options.UseDateOnlyTimeOnlyStringConverters();
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperProfile());
    cfg.AllowNullCollections = true;
}).CreateMapper());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseSwagger(c =>
{
    c.SerializeAsV2 = true;
});
app.UseMiddleware<ExceptionMiddleware>();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
