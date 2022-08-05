using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="OfiiceEmployee"/> to table dbo.OfiiceEmployee
    /// </summary>
    internal abstract class CodeBehindOfiiceEmployeeDatabaseMapping : EntityTypeConfiguration<OfiiceEmployee>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindOfiiceEmployeeDatabaseMapping()
        {
                ToTable("OfiiceEmployee", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name)
			    .HasColumnName("Name")
			    .IsRequired()
			    .IsUnicode();
            Property(t => t.OfficeId)
			    .HasColumnName("OfficeId")
			    .IsRequired();


            HasRequired(t => t.Office)
                .WithMany()
				.HasForeignKey(d =>  d.OfficeId);

        }
    }
}
