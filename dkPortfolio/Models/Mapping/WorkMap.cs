using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace dkPortfolio.Models.Mapping
{
    public class WorkMap : EntityTypeConfiguration<Work>
    {
        public WorkMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Type)
                .HasMaxLength(50);

            this.Property(t => t.Url)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Work");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AccountID).HasColumnName("AccountID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.PictureID).HasColumnName("PictureID");
            this.Property(t => t.LongText).HasColumnName("LongText");

            // Relationships
            this.HasOptional(t => t.Account)
                .WithMany(t => t.Works)
                .HasForeignKey(d => d.AccountID);
            this.HasOptional(t => t.Picture)
                .WithMany(t => t.Works)
                .HasForeignKey(d => d.PictureID);

        }
    }
}
