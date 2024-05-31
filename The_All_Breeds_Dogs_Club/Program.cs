using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace The_All_Breeds_Dogs_Club
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // —оздаем экземпл€р приложени€ с помощью WebApplication.CreateBuilder
            var builder = WebApplication.CreateBuilder(args);

            // ƒобавл€ем RazorPages в качестве сервиса в приложение
            builder.Services.AddRazorPages();

            // ѕолучаем строку подключени€ к базе данных из файла конфигурации
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            // ƒобавл€ем контекст ApplicationContext в качестве сервиса в приложение и указываем,
            // что дл€ подключени€ к базе данных следует использовать Npgsql (PostgreSQL)
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));

            // —оздаем экземпл€р приложени€
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // ѕеренаправл€ем все HTTP-запросы на HTTPS
            app.UseHttpsRedirection();

            // ќбеспечиваем доступ к статическим файлам (css, js, изображени€ и т.д.)
            app.UseStaticFiles();

            // Ќастраиваем маршрутизацию запросов
            app.UseRouting();

            // ќбеспечиваем авторизацию запросов
            app.UseAuthorization();

            // ќбеспечиваем обработку RazorPages
            app.MapRazorPages();

            // ќбработка запросов дл€ таблицы породы
            app.MapGet("/api/breeds", async (ApplicationContext db) => await db.породы.ToListAsync());

            app.MapGet("/api/breeds/{индекс_породы:int}", async (int индекс_породы, ApplicationContext db) =>
            {
                // получаем породу по id
                породы? breed = await db.породы.FirstOrDefaultAsync(u => u.индекс_породы == индекс_породы);

                // если не найдена, отправл€ем статусный код и сообщение об ошибке
                if (breed == null) return Results.NotFound(new { message = "ѕорода не найдена" });

                // если порода найдена, отправл€ем ее
                return Results.Json(breed);
            });

            app.MapDelete("/api/breeds/{индекс_породы:int}", async (int индекс_породы, ApplicationContext db) =>
            {
                try
                {
                    // получаем породу по id
                    породы? breed = await db.породы.FirstOrDefaultAsync(u => u.индекс_породы == индекс_породы);

                    // если не найдена, отправл€ем статусный код и сообщение об ошибке
                    if (breed == null) return Results.NotFound(new { message = "ѕорода не найдена" });

                    // если порода найдена, удал€ем ее
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
                // добавл€ем породу в массив
                await db.породы.AddAsync(breed);
                await db.SaveChangesAsync();
                return breed;
            });

            app.MapPut("/api/breeds", async (породы breedData, ApplicationContext db) =>
            {
                // получаем породу по id
                var breed = await db.породы.FirstOrDefaultAsync(u => u.индекс_породы == breedData.индекс_породы);

                // если не найдена, отправл€ем статусный код и сообщение об ошибке
                if (breed == null) return Results.NotFound(new { message = "ѕорода не найдена" });

                // если порода найдена, измен€ем ее данные и отправл€ем обратно клиенту
                breed.название = breedData.название;
                await db.SaveChangesAsync();
                return Results.Json(breed);
            });

            app.MapGet("/api/request/training", async (ApplicationContext db) =>
            {
                var query = from t in db.тренировки
                            join ts in db.собаки_тренировки on t.индекс_тренировки equals ts.индекс_тренировки
                            group ts by t.название into g
                            select new
                            {
                                Name = g.Key,
                                DogCount = g.Count()
                            };

                return await query.ToListAsync();
            });

            app.MapGet("/api/request/dogshow", async (ApplicationContext db) =>
            {
                var query = from t in db.выставки
                            join ts in db.собаки_выставки on t.индекс_выставки equals ts.индекс_выставки
                            group ts by t.название into g
                            select new
                            {
                                Name = g.Key,
                                DogCount = g.Count()
                            };

                return await query.ToListAsync();
            });

            // «апускаем приложение
            app.Run();
        }
    }
}
