using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TarefasBackEnd.Repositories;
using TarefasBackEnd.Repositories.ContosoUniversity.DAL;
using Microsoft.EntityFrameworkCore.InMemory;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configurar serviços
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("BDTarefas"));
var key = Encoding.ASCII.GetBytes("UmTokenMuitoGrandeDeSeDescobrir");

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
 .AddJwtBearer(x =>
 {
     x.RequireHttpsMetadata = false;
     x.SaveToken = true;
     x.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = new SymmetricSecurityKey(key),
         ValidateIssuer = false,
         ValidateAudience = false
     };
 });


var app = builder.Build();

// Configurar middleware
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();    

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello World!");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
