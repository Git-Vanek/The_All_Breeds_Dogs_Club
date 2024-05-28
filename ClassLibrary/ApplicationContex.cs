using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<администраторы> администраторы { get; set; }
        public DbSet<ветеринары> ветеринары { get; set; }
        public DbSet<выставки> выставки { get; set; }
        public DbSet<клубные_новости> клубные_новости { get; set; }
        public DbSet<клубные_рейтинги> клубные_рейтинги { get; set; }
        public DbSet<мероприятия> мероприятия { get; set; }
        public DbSet<организаторы> организаторы { get; set; }
        public DbSet<питомники> питомники { get; set; }
        public DbSet<пользователи> пользователи { get; set; }
        public DbSet<породы> породы { get; set; }
        public DbSet<результаты_осмотров_собак> результаты_осмотров_собак { get; set; }
        public DbSet<результаты_осмотров_собак_ветерин> результаты_осмотров_собак_ветерин { get; set; }
        public DbSet<роли> роли { get; set; }
        public DbSet<собаки> собаки { get; set; }
        public DbSet<собаки_выставки> собаки_выставки { get; set; }
        public DbSet<собаки_титулы> собаки_титулы { get; set; }
        public DbSet<собаки_тренировки> собаки_тренировки { get; set; }
        public DbSet<специализации> специализации { get; set; }
        public DbSet<титулы> титулы { get; set; }
        public DbSet<тренировки> тренировки { get; set; }
        public DbSet<участники> участники { get; set; }
        public DbSet<участники_мероприятия> участники_мероприятия { get; set; }
        public DbSet<участники_собаки> участники_собаки { get; set; }
    }
}
