using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BusinessFramework.WebAPI.Contracts.Files;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    ///     Database mapping for <see cref="FileLink" /> to table dbo.vCustomerList
    /// </summary>
    public sealed class FileLinkDatabaseMapping : EntityTypeConfiguration<FileLink>
    {
        /// <summary>
        ///     Instance constructor
        /// </summary>
        public FileLinkDatabaseMapping()
        {
            ToTable("Files", "CCSystem");

            HasKey(t => t.Id);

            Property(t => t.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.FileName)
                .HasColumnName("FileName")
                .IsRequired()
                .IsUnicode();

            Property(t => t.Length)
                .HasColumnName("Length")
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName("CreateDate")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Ignore(t => t.CreateDateNoOffset);

            Property(t => t.SysUserId)
                .HasColumnName("SysUserId")
                .IsRequired();

            Property(t => t.StorageName)
                .HasColumnName("StorageName")
                .IsRequired();

            Property(t => t.StorageLink)
                .HasColumnName("StorageLink")
                .IsRequired()
                .IsUnicode();

            Property(t => t.FieldId)
                .HasColumnName("FieldId")
                .IsRequired();

            Ignore(t => t.UploadLink);
        }
    }
}
