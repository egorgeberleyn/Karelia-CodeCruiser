using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SubTask"/> to table dbo.SubTask
    /// </summary>
    internal abstract class CodeBehindSubTaskDatabaseMapping : EntityTypeConfiguration<SubTask>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSubTaskDatabaseMapping()
        {
                ToTable("SubTask", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Description)
			    .HasColumnName("Description")
			    .IsUnicode();
            Property(t => t.Name)
			    .HasColumnName("Name")
			    .IsRequired()
			    .IsUnicode();
            Property(t => t.Sequence)
			    .HasColumnName("Sequence");
            Property(t => t.TaskId)
			    .HasColumnName("TaskId")
			    .IsRequired();


            HasRequired(t => t.MainTask)
                .WithMany()
				.HasForeignKey(d =>  d.TaskId);

        }
    }
}
