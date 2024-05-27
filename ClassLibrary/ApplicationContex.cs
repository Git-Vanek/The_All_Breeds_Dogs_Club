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

        public DbSet<пользователи> пользователи { get; set; } = null!;
        public DbSet<роли> роли { get; set; } = null!;

        private static ApplicationContext _contex;
        internal static ApplicationContext GetContex()
        {
            if (_contex == null)
                _contex = new ApplicationContext();
            return _contex;
        }
    }
}
