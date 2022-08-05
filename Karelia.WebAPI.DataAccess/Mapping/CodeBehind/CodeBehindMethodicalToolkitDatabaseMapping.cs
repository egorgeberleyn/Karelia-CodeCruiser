using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="MethodicalToolkit"/> to table dbo.MethodicalToolkit
    /// </summary>
    internal abstract class CodeBehindMethodicalToolkitDatabaseMapping : EntityTypeConfiguration<MethodicalToolkit>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindMethodicalToolkitDatabaseMapping()
        {
                ToTable("MethodicalToolkit", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name)
			    .HasColumnName("Name")
			    .IsRequired()
			    .IsUnicode();
        }
    }
}
