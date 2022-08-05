using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysPermissionType"/> to table CCSystem.PermissionTypes
    /// </summary>
    internal abstract class CodeBehindSysPermissionTypeDatabaseMapping : EntityTypeConfiguration<SysPermissionType>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysPermissionTypeDatabaseMapping()
        {
                ToTable("PermissionTypes", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired();
            Property(t => t.CodeName)
			    .HasColumnName("CodeName")
			    .IsRequired();
            Property(t => t.Description)
			    .HasColumnName("Description")
			    .IsUnicode();
            Property(t => t.DisplayName)
			    .HasColumnName("DisplayName")
			    .IsRequired()
			    .IsUnicode();
        }
    }
}
