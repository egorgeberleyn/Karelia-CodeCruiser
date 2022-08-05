using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysUserRole"/> to table CCSystem.UserRoles
    /// </summary>
    internal abstract class CodeBehindSysUserRoleDatabaseMapping : EntityTypeConfiguration<SysUserRole>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysUserRoleDatabaseMapping()
        {
                ToTable("UserRoles", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.RoleId)
			    .HasColumnName("RoleId")
			    .IsRequired();
            Property(t => t.UserId)
			    .HasColumnName("UserId")
			    .IsRequired();


            HasRequired(t => t.SysRole)
                .WithMany()
				.HasForeignKey(d =>  d.RoleId);

            HasRequired(t => t.SysUser)
                .WithMany()
				.HasForeignKey(d =>  d.UserId);

        }
    }
}
