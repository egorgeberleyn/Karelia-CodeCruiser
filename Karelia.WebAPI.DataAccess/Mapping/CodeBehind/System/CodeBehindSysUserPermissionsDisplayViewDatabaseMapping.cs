using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysUserPermissionsDisplayView"/> to table CCSystem.UserPermissionsDisplayView
    /// </summary>
    internal abstract class CodeBehindSysUserPermissionsDisplayViewDatabaseMapping : EntityTypeConfiguration<SysUserPermissionsDisplayView>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysUserPermissionsDisplayViewDatabaseMapping()
        {
                ToTable("UserPermissionsDisplayView", "CCSystem");
            HasKey(t => new{t.UserId, t.PermissionId});

            Property(t => t.UserId)
			    .HasColumnName("UserId")
			    .IsRequired();
            Property(t => t.PermissionId)
			    .HasColumnName("PermissionId")
			    .IsRequired();
            Property(t => t.PermissionName)
			    .HasColumnName("PermissionName")
			    .IsUnicode();
            Property(t => t.Roles)
			    .HasColumnName("Roles")
			    .IsUnicode();
        }
    }
}
