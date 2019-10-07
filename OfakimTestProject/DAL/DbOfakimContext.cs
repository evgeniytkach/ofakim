using OfakimTestProject.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OfakimTestProject.DAL
{
    public class DbOfakimContext : DbContext
    {

        public DbOfakimContext() : base("OfakimConnection")
        {
            SetCommandTimeOut(0);
        }

        public void SetCommandTimeOut(int Timeout)
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = Timeout;
        }

        public DbSet<CurrencySourceDataModel> CurrencySources { get; set; }
        public DbSet<CurrencyPairModel> CurrencyPairs { get; set; }
        public DbSet<CurrencyDataModel> CurrencyData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DbOfakimContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}