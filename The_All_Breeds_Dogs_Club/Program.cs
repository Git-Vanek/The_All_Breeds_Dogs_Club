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

            // Обработка запросов для таблицы породы
            app.MapGet("/api/breeds", async (ApplicationContext db) => await db.породы.ToListAsync());

            app.MapGet("/api/breeds/{индекс_породы:int}", async (int индекс_породы, ApplicationContext db) =>
            {
                // получаем породу по id
                породы? breed = await db.породы.FirstOrDefaultAsync(u => u.индекс_породы == индекс_породы);

                // если не найдена, отправляем статусный код и сообщение об ошибке
                if (breed == null) return Results.NotFound(new { message = "Порода не найдена" });

                // если порода найдена, отправляем ее
                return Results.Json(breed);
            });

            app.MapDelete("/api/breeds/{индекс_породы:int}", async (int индекс_породы, ApplicationContext db) =>
            {
                try
                {
                    // получаем породу по id
                    породы? breed = await db.породы.FirstOrDefaultAsync(u => u.индекс_породы == индекс_породы);

                    // если не найдена, отправляем статусный код и сообщение об ошибке
                    if (breed == null) return Results.NotFound(new { message = "Порода не найдена" });

                    // если порода найдена, удаляем ее
                    db.породы.Remove(breed);
                    await db.SaveChangesAsync();
                    return Results.Json(breed);
                }
                catch
                {
                    throw new Exception();
                }
            });

            app.MapPost("/api/breeds", async (породы breed, ApplicationContext db) =>
            {
                // добавляем породу в массив
                await db.породы.AddAsync(breed);
                await db.SaveChangesAsync();
                return breed;
            });

            app.MapPut("/api/breeds", async (породы breedData, ApplicationContext db) =>
            {
                // получаем породу по id
                var breed = await db.породы.FirstOrDefaultAsync(u => u.индекс_породы == breedData.индекс_породы);

                // если не найдена, отправляем статусный код и сообщение об ошибке
                if (breed == null) return Results.NotFound(new { message = "Порода не найдена" });

                // если порода найдена, изменяем ее данные и отправляем обратно клиенту
                breed.название = breedData.название;
                await db.SaveChangesAsync();
                return Results.Json(breed);
            });

            // Запускаем приложение
            app.Run();
        }
    }
}
