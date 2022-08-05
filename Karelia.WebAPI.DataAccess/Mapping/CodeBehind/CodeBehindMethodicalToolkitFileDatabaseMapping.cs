using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="MethodicalToolkitFile"/> to table dbo.MethodicalToolkitFile
    /// </summary>
    internal abstract class CodeBehindMethodicalToolkitFileDatabaseMapping : EntityTypeConfiguration<MethodicalToolkitFile>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindMethodicalToolkitFileDatabaseMapping()
        {
                ToTable("MethodicalToolkitFile", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Description)
			    .HasColumnName("Description")
			    .IsUnicode();
            Property(t => t.MethodicalToolkitId)
			    .HasColumnName("MethodicalToolkitId")
			    .IsRequired();
            Property(t => t.Name)
			    .HasColumnName("Name")
			    .IsRequired()
			    .IsUnicode();


            HasRequired(t => t.MethodicalToolkit)
                .WithMany()
				.HasForeignKey(d =>  d.MethodicalToolkitId);

        }
    }
}
