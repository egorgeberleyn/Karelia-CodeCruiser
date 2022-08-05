using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysObjectType"/> to table CCSystem.ObjectTypes
    /// </summary>
    internal abstract class CodeBehindSysObjectTypeDatabaseMapping : EntityTypeConfiguration<SysObjectType>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysObjectTypeDatabaseMapping()
        {
                ToTable("ObjectTypes", "CCSystem");
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
