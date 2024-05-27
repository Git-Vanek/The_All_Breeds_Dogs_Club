using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<администраторы> администраторы { get; set; } = null!;
        public DbSet<ветеринары> ветеринары { get; set; } = null!;
        public DbSet<выставки> выставки { get; set; } = null!;
        public DbSet<клубные_новости> клубные_новости { get; set; } = null!;
        public DbSet<клубные_рейтинги> клубные_рейтинги { get; set; } = null!;
        public DbSet<мероприятия> мероприятия { get; set; } = null!;
        public DbSet<организаторы> организаторы { get; set; } = null!;
        public DbSet<питомники> питомники { get; set; } = null!;
        public DbSet<пользователи> пользователи { get; set; } = null!;
        public DbSet<породы> породы { get; set; } = null!;
        public DbSet<результаты_осмотров_собак> результаты_осмотров_собак { get; set; } = null!;
        public DbSet<результаты_осмотров_собак_ветерин> результаты_осмотров_собак_ветерин { get; set; } = null!;
        public DbSet<роли> роли { get; set; } = null!;
        public DbSet<собаки> собаки { get; set; } = null!;
        public DbSet<собаки_выставки> собаки_выставки { get; set; } = null!;
        public DbSet<собаки_титулы> собаки_титулы { get; set; } = null!;
        public DbSet<собаки_тренировки> собаки_тренировки { get; set; } = null!;
        public DbSet<специализации> специализации { get; set; } = null!;
        public DbSet<титулы> титулы { get; set; } = null!;
        public DbSet<тренировки> тренировки { get; set; } = null!;
        public DbSet<участники> участники { get; set; } = null!;
        public DbSet<участники_мероприятия> участники_мероприятия { get; set; } = null!;
        public DbSet<участники_собаки> участники_собаки { get; set; } = null!;

        private static ApplicationContext _context;
        internal static ApplicationContext GetContex()
        {
            if (_context == null)
                _context = new ApplicationContext();
            return _context;
        }
    }
}
