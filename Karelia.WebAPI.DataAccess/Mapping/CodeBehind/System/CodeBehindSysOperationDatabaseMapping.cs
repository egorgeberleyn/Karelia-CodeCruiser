using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysOperation"/> to table CCSystem.Operation
    /// </summary>
    internal abstract class CodeBehindSysOperationDatabaseMapping : EntityTypeConfiguration<SysOperation>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysOperationDatabaseMapping()
        {
                ToTable("Operation", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.ActionId)
			    .HasColumnName("ActionId")
			    .IsRequired();
            Property(t => t.Date)
			    .HasColumnName("Date")
			    .IsRequired();
            Property(t => t.OperationDetails)
			    .HasColumnName("OperationDetails")
			    .IsUnicode();
            Property(t => t.OperationResultId)
			    .HasColumnName("OperationResultId")
			    .IsRequired();
            Property(t => t.Request)
			    .HasColumnName("Request")
			    .IsUnicode();
            Property(t => t.RequestContent)
			    .HasColumnName("RequestContent")
			    .IsUnicode();
            Property(t => t.UserID)
			    .HasColumnName("UserID")
			    .IsRequired();


            HasRequired(t => t.SysUser)
                .WithMany()
				.HasForeignKey(d =>  d.UserID);

            HasRequired(t => t.Action)
                .WithMany()
				.HasForeignKey(d =>  d.ActionId);

            HasRequired(t => t.OperationResult)
                .WithMany()
				.HasForeignKey(d =>  d.OperationResultId);

        }
    }
}
