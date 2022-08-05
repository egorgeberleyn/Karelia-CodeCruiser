using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysRefreshToken"/> to table CCSystem.RefreshToken
    /// </summary>
    internal abstract class CodeBehindSysRefreshTokenDatabaseMapping : EntityTypeConfiguration<SysRefreshToken>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysRefreshTokenDatabaseMapping()
        {
                ToTable("RefreshToken", "CCSystem");
            HasKey(t => new{t.UserId, t.ClientId});

            Property(t => t.UserId)
			    .HasColumnName("UserId")
			    .IsRequired();
            Property(t => t.ClientId)
			    .HasColumnName("ClientId")
			    .IsRequired();
            Property(t => t.ExpiresUtc)
			    .HasColumnName("ExpiresUtc")
			    .IsRequired();
            Property(t => t.Token)
			    .HasColumnName("Token")
			    .IsRequired();


            HasRequired(t => t.SysUser)
                .WithMany()
				.HasForeignKey(d =>  d.UserId);

        }
    }
}
