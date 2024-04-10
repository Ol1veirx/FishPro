using System.Text;
using FishPro.Application.Mappings;
using FishPro.Application.Services.Implementations;
using FishPro.Application.Services.Interfaces;
using FishPro.Core.Account;
using FishPro.Infraestructure.Identity;
using FishPro.Infraestructure.Persistence;
using FishPro.Infraestructure.Repositories;
using FishPro.Infraestructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<FpDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("FishProConnectionString");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IStageRepository, StageRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IResultRepository, ResultRepository>();

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<IStageServices, StageServices>();
builder.Services.AddScoped<ITeamServices, TeamServices>();
builder.Services.AddScoped<IResultServices, ResultServices>();

builder.Services.AddScoped<IAuthenticate, AuthenticateService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["jwt:issuer"],
        ValidAudience = builder.Configuration["jwt:audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["jwt:secretKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

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
