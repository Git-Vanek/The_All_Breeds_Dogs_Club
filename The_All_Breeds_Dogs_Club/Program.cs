using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace The_All_Breeds_Dogs_Club
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Создаем экземпляр приложения с помощью WebApplication.CreateBuilder
            var builder = WebApplication.CreateBuilder(args);

            // Добавляем RazorPages в качестве сервиса в приложение
            builder.Services.AddRazorPages();

            // Получаем строку подключения к базе данных из файла конфигурации
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            // Добавляем контекст ApplicationContext в качестве сервиса в приложение и указываем,
            // что для подключения к базе данных следует использовать Npgsql (PostgreSQL)
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));

            // Создаем экземпляр приложения
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Перенаправляем все HTTP-запросы на HTTPS
            app.UseHttpsRedirection();

            // Обеспечиваем доступ к статическим файлам (css, js, изображения и т.д.)
            app.UseStaticFiles();

            // Настраиваем маршрутизацию запросов
            app.UseRouting();

            // Обеспечиваем авторизацию запросов
            app.UseAuthorization();

            // Обеспечиваем обработку RazorPages
            app.MapRazorPages();

            // Запускаем приложение
            app.Run();
        }
    }
}
