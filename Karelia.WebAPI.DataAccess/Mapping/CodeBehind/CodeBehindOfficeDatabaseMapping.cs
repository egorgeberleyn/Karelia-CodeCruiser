using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="Office"/> to table dbo.Office
    /// </summary>
    internal abstract class CodeBehindOfficeDatabaseMapping : EntityTypeConfiguration<Office>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindOfficeDatabaseMapping()
        {
                ToTable("Office", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Adress)
			    .HasColumnName("Adress")
			    .IsRequired()
			    .IsUnicode();
        }
    }
}
