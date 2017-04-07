using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace dkPortfolio.Models.Mapping
{
    public class MailMap : EntityTypeConfiguration<Mail>
    {
        public MailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.NameSurname)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Subject)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Mail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.NameSurname).HasColumnName("NameSurname");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.Text).HasColumnName("Text");
        }
    }
}
