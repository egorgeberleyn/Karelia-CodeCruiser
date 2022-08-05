using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="MainTask"/> to table dbo.MainTask
    /// </summary>
    internal abstract class CodeBehindMainTaskDatabaseMapping : EntityTypeConfiguration<MainTask>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindMainTaskDatabaseMapping()
        {
                ToTable("MainTask", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Comments)
			    .HasColumnName("Comments")
			    .IsUnicode();
            Property(t => t.CreationDate)
			    .HasColumnName("CreationDate");
            Property(t => t.EmployeeId)
			    .HasColumnName("EmployeeId")
			    .IsRequired();
            Property(t => t.EndDate)
			    .HasColumnName("EndDate");
            Property(t => t.IsCompleted)
			    .HasColumnName("IsCompleted")
			    .IsRequired();
            Property(t => t.Name)
			    .HasColumnName("Name")
			    .IsRequired()
			    .IsUnicode();


            HasRequired(t => t.Employee)
                .WithMany()
				.HasForeignKey(d =>  d.EmployeeId);

        }
    }
}
