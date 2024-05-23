
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;
using TakGhahCore.Repostiory;
using TakGhahCore.Service;
using TakGhahCore.UOF;
using TakGhahDataLayer.Context;

namespace TakGhahServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region AddSwaggers
            builder.Services.AddSwaggerGen(options =>
            {
                options.InferSecuritySchemes();
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}
        }
    });
            });
            builder.Services.Configure<SwaggerGeneratorOptions>(options =>
            {
                options.InferSecuritySchemes = true;
            });
            #endregion

            #region AddAuthentiation
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://api.GhorfeDar.com/",
                        ValidAudience = "token",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("43443FDFDF34DF34343fdf344SDFSDFSDFSDFSDF4545354345SDFGDFGDFGDFGdffgfdGDFGDGR%"))
                    };
                });
            #endregion

            #region DbContext
            builder.Services.AddDbContext<TakGhahContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString"));
                //options.UseSqlServer("Data Source=195.201.56.98,2019;Initial Catalog=GhorfeDarDb;Persist Security Info=True;TrustServerCertificate=True;User ID=GhorfeDar;Password=14Recb6%");
                // options.UseSqlServer("Data Source=.;Initial Catalog=GhorfeDarDb;Integrated Security=true;Trust Server Certificate=true");
            });
            #endregion

            #region IoC
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<UnitOfWork>();
            #endregion
            // Add services to the container.
            #region AddNetonJson
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            #endregion
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
