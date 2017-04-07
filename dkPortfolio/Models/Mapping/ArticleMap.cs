using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace dkPortfolio.Models.Mapping
{
    public class ArticleMap : EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Header)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Article");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Header).HasColumnName("Header");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.PictureID).HasColumnName("PictureID");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.AccountID).HasColumnName("AccountID");

            // Relationships
            this.HasMany(t => t.Tags)
                .WithMany(t => t.Articles)
                .Map(m =>
                    {
                        m.ToTable("TagArticle");
                        m.MapLeftKey("ArticleID");
                        m.MapRightKey("TagID");
                    });

            this.HasOptional(t => t.Account)
                .WithMany(t => t.Articles)
                .HasForeignKey(d => d.AccountID);
            this.HasOptional(t => t.Picture)
                .WithMany(t => t.Articles)
                .HasForeignKey(d => d.PictureID);

        }
    }
}
