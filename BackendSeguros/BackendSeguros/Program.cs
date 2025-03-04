using System.Text;
using BackendSeguros.Data;
using BackendSeguros.Mappers;
using BackendSeguros.Repositorio;
using BackendSeguros.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Agregamos el serivicio de la Bd

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));


///Agregamos los Repositorios
builder.Services.AddScoped<IRamoRepositorio, RamoRepositorio>();
builder.Services.AddScoped<ICoberturaRepositorio, CoberturaRepository>();
builder.Services.AddScoped<ICorredorRepositorio, CorredorRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IPolizaRepositorio, PolizaRepositorio>();

//Agrefar servicio MAPPER
//Agregar el AutoMapper

builder.Services.AddAutoMapper(typeof(MappearClass));

//Agregar el cORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCors", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Cambia esto por la URL de tu frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Description = "Autenticación JWT usando el esquema Bearer. \r\n\r\n " +
                  "Ingresa la palabra 'Bearer' seguida de un espacio y luego el token. \r\n\r\n" +
                  "Ejemplo: \"Bearer tu_token_aqui\"",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    BearerFormat = "JWT"
});
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

var key = builder.Configuration.GetValue<string>("ApiSettings:Secreta");
builder.Services.AddAuthentication(
        x =>
        {
            //Agrefar y configurar la aplicacion
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }
        ).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
        );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PoliticaCors");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
