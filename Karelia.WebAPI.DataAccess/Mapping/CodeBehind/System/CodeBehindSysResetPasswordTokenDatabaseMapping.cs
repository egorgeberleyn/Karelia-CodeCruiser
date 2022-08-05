using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysResetPasswordToken"/> to table CCSystem.ResetPasswordToken
    /// </summary>
    internal abstract class CodeBehindSysResetPasswordTokenDatabaseMapping : EntityTypeConfiguration<SysResetPasswordToken>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysResetPasswordTokenDatabaseMapping()
        {
                ToTable("ResetPasswordToken", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.IsExecuted)
			    .HasColumnName("IsExecuted")
			    .IsRequired();
            Property(t => t.Token)
			    .HasColumnName("Token")
			    .IsRequired();
            Property(t => t.UserId)
			    .HasColumnName("UserId")
			    .IsRequired();
            Property(t => t.ValidFrom)
			    .HasColumnName("ValidFrom")
			    .IsRequired();


            HasRequired(t => t.SysUser)
                .WithMany()
				.HasForeignKey(d =>  d.UserId);

        }
    }
}
