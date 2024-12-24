using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace flowersAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Подключение базы данных
            builder.Services.AddDbContext<Flower_ServiceContext>(
                options => options.UseSqlServer(
                    "Server=HASHIRAMA\\PSSQLSERVER;Database=Flower_Service;Integrated Security=True;TrustServerCertificate=True;"));

            // Регистрация сервисов
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddAuthorization();
            builder.Services.AddControllers(); // Добавляем регистрацию контроллеров

            var app = builder.Build();

            // Настройка middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers(); // Подключение маршрутов контроллеров

            app.Run();
        }
    }
}