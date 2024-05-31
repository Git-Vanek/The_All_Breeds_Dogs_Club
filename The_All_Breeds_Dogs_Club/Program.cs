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
            // ������� ��������� ���������� � ������� WebApplication.CreateBuilder
            var builder = WebApplication.CreateBuilder(args);

            // ��������� RazorPages � �������� ������� � ����������
            builder.Services.AddRazorPages();

            // �������� ������ ����������� � ���� ������ �� ����� ������������
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            // ��������� �������� ApplicationContext � �������� ������� � ���������� � ���������,
            // ��� ��� ����������� � ���� ������ ������� ������������ Npgsql (PostgreSQL)
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));

            // ������� ��������� ����������
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // �������������� ��� HTTP-������� �� HTTPS
            app.UseHttpsRedirection();

            // ������������ ������ � ����������� ������ (css, js, ����������� � �.�.)
            app.UseStaticFiles();

            // ����������� ������������� ��������
            app.UseRouting();

            // ������������ ����������� ��������
            app.UseAuthorization();

            // ������������ ��������� RazorPages
            app.MapRazorPages();

            // ��������� �������� ��� ������� ������
            app.MapGet("/api/breeds", async (ApplicationContext db) => await db.������.ToListAsync());

            app.MapGet("/api/breeds/{������_������:int}", async (int ������_������, ApplicationContext db) =>
            {
                // �������� ������ �� id
                ������? breed = await db.������.FirstOrDefaultAsync(u => u.������_������ == ������_������);

                // ���� �� �������, ���������� ��������� ��� � ��������� �� ������
                if (breed == null) return Results.NotFound(new { message = "������ �� �������" });

                // ���� ������ �������, ���������� ��
                return Results.Json(breed);
            });

            app.MapDelete("/api/breeds/{������_������:int}", async (int ������_������, ApplicationContext db) =>
            {
                try
                {
                    // �������� ������ �� id
                    ������? breed = await db.������.FirstOrDefaultAsync(u => u.������_������ == ������_������);

                    // ���� �� �������, ���������� ��������� ��� � ��������� �� ������
                    if (breed == null) return Results.NotFound(new { message = "������ �� �������" });

                    // ���� ������ �������, ������� ��
                    db.������.Remove(breed);
                    await db.SaveChangesAsync();
                    return Results.Json(breed);
                }
                catch
                {
                    throw new Exception();
                }
            });

            app.MapPost("/api/breeds", async (������ breed, ApplicationContext db) =>
            {
                // ��������� ������ � ������
                await db.������.AddAsync(breed);
                await db.SaveChangesAsync();
                return breed;
            });

            app.MapPut("/api/breeds", async (������ breedData, ApplicationContext db) =>
            {
                // �������� ������ �� id
                var breed = await db.������.FirstOrDefaultAsync(u => u.������_������ == breedData.������_������);

                // ���� �� �������, ���������� ��������� ��� � ��������� �� ������
                if (breed == null) return Results.NotFound(new { message = "������ �� �������" });

                // ���� ������ �������, �������� �� ������ � ���������� ������� �������
                breed.�������� = breedData.��������;
                await db.SaveChangesAsync();
                return Results.Json(breed);
            });

            app.MapGet("/api/request/training", async (ApplicationContext db) =>
            {
                var query = from t in db.����������
                            join ts in db.������_���������� on t.������_���������� equals ts.������_����������
                            group ts by t.�������� into g
                            select new
                            {
                                Name = g.Key,
                                DogCount = g.Count()
                            };

                return await query.ToListAsync();
            });

            app.MapGet("/api/request/dogshow", async (ApplicationContext db) =>
            {
                var query = from t in db.��������
                            join ts in db.������_�������� on t.������_�������� equals ts.������_��������
                            group ts by t.�������� into g
                            select new
                            {
                                Name = g.Key,
                                DogCount = g.Count()
                            };

                return await query.ToListAsync();
            });

            // ��������� ����������
            app.Run();
        }
    }
}
