using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

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

            // ��������� ����������
            app.Run();
        }
    }
}
