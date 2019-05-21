using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Library.Models
{
    public class BookContext : DbContext
    {
        public BookContext() : base("BookContext")
        {
        }
		
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
