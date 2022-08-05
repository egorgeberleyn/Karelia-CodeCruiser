using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysRolePermission"/> to table CCSystem.RolePermissions
    /// </summary>
    internal abstract class CodeBehindSysRolePermissionDatabaseMapping : EntityTypeConfiguration<SysRolePermission>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysRolePermissionDatabaseMapping()
        {
                ToTable("RolePermissions", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.PermissionId)
			    .HasColumnName("PermissionId")
			    .IsRequired();
            Property(t => t.RoleId)
			    .HasColumnName("RoleId")
			    .IsRequired();


            HasRequired(t => t.SysRole)
                .WithMany(t => t.SysRolePermissions)
				.HasForeignKey(d =>  d.RoleId);

            HasRequired(t => t.SysPermission)
                .WithMany()
				.HasForeignKey(d =>  d.PermissionId);

        }
    }
}
