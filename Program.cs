using AppEscolaDeMusica.DataContexts;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using AppEscolaDeMusica.Profiles;
using AppEscolaDeMusica.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("mysql");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32)))
                      .UseSnakeCaseNamingConvention()
);

builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });



/**
 * Configuração de Versionamento de API
 */
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

/**
 * Config. de Verificação de Autenticação - JWT
 */
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = 
                new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty))
        };
    });

builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Escola de Música - V1",
        Description = "API de consumo para aplicação Escola de Música"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Cabeçalho de autorização JWT. Usando esquema de Bearer \r\n\r\n Digite 'Bearer + token'. Ex.: 'Bearer 123...'"
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
         Array.Empty<string>()
        }
    });
});

// Registrar Services
builder.Services.AddScoped<ResponsavelAlunoService>();
builder.Services.AddScoped<AlunoService>();
builder.Services.AddScoped<ProfessorService>();
builder.Services.AddScoped<CursoService>();

// Registrar AutoMapper Profiles
builder.Services.AddAutoMapper(config => {
   config.AddProfile<ResponsavelAlunoProfile>();
   config.AddProfile<AlunoProfile>();
   config.AddProfile<ProfessorProfile>();
   config.AddProfile<CursoProfile>();
});

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
