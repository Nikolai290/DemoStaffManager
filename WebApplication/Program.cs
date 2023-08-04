using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using DemoStaffManager.Business.DataTransferObjects.AutoMapperProfiles;
using DemoStaffManager.Domain.Implementation;
using Microsoft.EntityFrameworkCore;
using WebApplication.IoC;

namespace DemoStaffManager.WebApplication
{
    public class Program
    {
        public static void Main(params string[] args)
        {
            var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.SetMinimumLevel(LogLevel.Debug);
            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options => new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var allowOrigins = builder.Configuration.GetSection("AllowOrigins").Value;
            var connectionString = builder.Configuration.GetConnectionString("MsSqlServer");
            builder.Services.AddDbContext<MsSqlContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString));
            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "DefaultPolicy",
                    policy =>
                    {
                        policy
                            .WithOrigins(allowOrigins)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            builder.Services.AddAutoMapper(config => config.AddProfile(typeof(DefaultMapperProfile)));
            builder.Services.AddRepositories();
            builder.Services.AddServices();
            builder.Services.AddValidators();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("DefaultPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
        
    }
}


