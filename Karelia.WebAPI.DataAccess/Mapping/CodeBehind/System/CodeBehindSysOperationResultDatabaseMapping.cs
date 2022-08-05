using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysOperationResult"/> to table CCSystem.OperationResult
    /// </summary>
    internal abstract class CodeBehindSysOperationResultDatabaseMapping : EntityTypeConfiguration<SysOperationResult>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysOperationResultDatabaseMapping()
        {
                ToTable("OperationResult", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired();
            Property(t => t.Name)
			    .HasColumnName("Name")
			    .IsRequired()
			    .IsUnicode();
        }
    }
}
