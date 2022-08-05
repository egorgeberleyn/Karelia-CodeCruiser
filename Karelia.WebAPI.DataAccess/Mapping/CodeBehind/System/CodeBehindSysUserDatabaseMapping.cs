using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysUser"/> to table CCSystem.Users
    /// </summary>
    internal abstract class CodeBehindSysUserDatabaseMapping : EntityTypeConfiguration<SysUser>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysUserDatabaseMapping()
        {
                ToTable("Users", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.AccountName)
			    .HasColumnName("AccountName")
			    .IsRequired()
			    .IsUnicode();
            Property(t => t.CreateDate)
			    .HasColumnName("CreateDate")
			    .IsRequired();
            Property(t => t.DeactivationDate)
			    .HasColumnName("DeactivationDate");
            Property(t => t.Description)
			    .HasColumnName("Description")
			    .IsUnicode();
            Property(t => t.DisplayName)
			    .HasColumnName("DisplayName")
			    .IsRequired()
			    .IsUnicode();
            Property(t => t.EMail)
			    .HasColumnName("EMail")
			    .IsUnicode();
            Property(t => t.EmailToken)
			    .HasColumnName("EmailToken");
            Property(t => t.FullAccess)
			    .HasColumnName("FullAccess")
			    .IsRequired();
            Property(t => t.IsAnonymous)
			    .HasColumnName("IsAnonymous")
			    .IsRequired();
            Property(t => t.IsDeactivated)
			    .HasColumnName("IsDeactivated")
			    .IsRequired();
            Property(t => t.IsEmailConfirmed)
			    .HasColumnName("IsEmailConfirmed")
			    .IsRequired();
            Property(t => t.IsSystemUser)
			    .HasColumnName("IsSystemUser")
			    .IsRequired();
            Property(t => t.PasswordHash)
			    .HasColumnName("PasswordHash");
        }
    }
}
