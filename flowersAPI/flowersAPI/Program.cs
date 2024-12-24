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

            // ����������� ���� ������
            builder.Services.AddDbContext<Flower_ServiceContext>(
                options => options.UseSqlServer(
                    "Server=HASHIRAMA\\PSSQLSERVER;Database=Flower_Service;Integrated Security=True;TrustServerCertificate=True;"));

            // ����������� ��������
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddAuthorization();
            builder.Services.AddControllers(); // ��������� ����������� ������������

            var app = builder.Build();

            // ��������� middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers(); // ����������� ��������� ������������

            app.Run();
        }
    }
}