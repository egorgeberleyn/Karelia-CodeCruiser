using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysOperationLock"/> to table CCSystem.OperationLocks
    /// </summary>
    internal abstract class CodeBehindSysOperationLockDatabaseMapping : EntityTypeConfiguration<SysOperationLock>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysOperationLockDatabaseMapping()
        {
                ToTable("OperationLocks", "CCSystem");
            HasKey(t => new{t.OperationName, t.OperationContext});

            Property(t => t.OperationName)
			    .HasColumnName("OperationName")
			    .IsRequired()
			    .IsUnicode();
            Property(t => t.OperationContext)
			    .HasColumnName("OperationContext")
			    .IsRequired()
			    .IsUnicode();
            Property(t => t.AquiredTime)
			    .HasColumnName("AquiredTime")
			    .IsRequired();
            Property(t => t.ExpirationTime)
			    .HasColumnName("ExpirationTime")
			    .IsRequired();
            Property(t => t.MachineName)
			    .HasColumnName("MachineName")
			    .IsUnicode();
            Property(t => t.ProcessId)
			    .HasColumnName("ProcessId");
            Property(t => t.UserId)
			    .HasColumnName("UserId")
			    .IsRequired();


            HasRequired(t => t.SysUser)
                .WithMany()
				.HasForeignKey(d =>  d.UserId);

        }
    }
}
