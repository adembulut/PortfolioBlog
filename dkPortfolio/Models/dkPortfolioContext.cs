using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using dkPortfolio.Models.Mapping;

namespace dkPortfolio.Models
{
    public partial class dkPortfolioContext : DbContext
    {
        static dkPortfolioContext()
        {
            Database.SetInitializer<dkPortfolioContext>(null);
        }

        public dkPortfolioContext()
            : base("Name=dkPortfolioContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new LinkMap());
            modelBuilder.Configurations.Add(new MailMap());
            modelBuilder.Configurations.Add(new OptionMap());
            modelBuilder.Configurations.Add(new PictureMap());
            modelBuilder.Configurations.Add(new ProgressMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new WorkMap());
        }
    }
}
