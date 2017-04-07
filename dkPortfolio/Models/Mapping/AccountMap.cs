using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace dkPortfolio.Models.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.ShortAbout)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Account");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Surname).HasColumnName("Surname");
            this.Property(t => t.Birthday).HasColumnName("Birthday");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.About).HasColumnName("About");
            this.Property(t => t.ShortAbout).HasColumnName("ShortAbout");
            this.Property(t => t.PictureID).HasColumnName("PictureID");
            this.Property(t => t.isAdmin).HasColumnName("isAdmin");

            // Relationships
            this.HasOptional(t => t.Picture)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.PictureID);

        }
    }
}
