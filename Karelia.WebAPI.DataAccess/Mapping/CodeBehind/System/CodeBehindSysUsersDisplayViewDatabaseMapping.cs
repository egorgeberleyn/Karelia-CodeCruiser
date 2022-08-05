using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysUsersDisplayView"/> to table CCSystem.UsersDisplayView
    /// </summary>
    internal abstract class CodeBehindSysUsersDisplayViewDatabaseMapping : EntityTypeConfiguration<SysUsersDisplayView>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysUsersDisplayViewDatabaseMapping()
        {
                ToTable("UsersDisplayView", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired();
            Property(t => t.UserRoleId)
			    .HasColumnName("UserRoleId");


            HasRequired(t => t.SysUser)
                .WithRequiredDependent(t => t.SysUsersDisplayView);

        }
    }
}
