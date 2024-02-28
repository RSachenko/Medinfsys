using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Medinfsys.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Метод ConfigureServices для настройки сервисов
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:5000") // Укажите адрес вашего основного проекта
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            // Другие настройки сервисов...
        }

        // Метод Configure для настройки конвейера обработки запросов
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Другие конфигурации...

            // Включение CORS
            app.UseCors("AllowOrigin");

            // Другие конфигурации...
        }
    }
}