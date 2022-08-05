using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysInfo"/> to table CCSystem.Info
    /// </summary>
    internal abstract class CodeBehindSysInfoDatabaseMapping : EntityTypeConfiguration<SysInfo>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysInfoDatabaseMapping()
        {
                ToTable("Info", "CCSystem");
            HasKey(t => new{t.SystemVersion, t.DomainVersion, t.LastInitialization});

            Property(t => t.SystemVersion)
			    .HasColumnName("SystemVersion")
			    .IsRequired();
            Property(t => t.DomainVersion)
			    .HasColumnName("DomainVersion")
			    .IsRequired();
            Property(t => t.LastInitialization)
			    .HasColumnName("LastInitialization")
			    .IsRequired();
        }
    }
}
