using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="CarServiceWork"/> to table dbo.CarServiceWork
    /// </summary>
    internal abstract class CodeBehindCarServiceWorkDatabaseMapping : EntityTypeConfiguration<CarServiceWork>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindCarServiceWorkDatabaseMapping()
        {
                ToTable("CarServiceWork", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CarServiceId)
			    .HasColumnName("CarServiceId")
			    .IsRequired();
            Property(t => t.CarWorkTypeId)
			    .HasColumnName("CarWorkTypeId")
			    .IsRequired();
            Property(t => t.Comments)
			    .HasColumnName("Comments")
			    .IsUnicode();


            HasRequired(t => t.CarService)
                .WithMany()
				.HasForeignKey(d =>  d.CarServiceId);

            HasRequired(t => t.CarWorkType)
                .WithMany()
				.HasForeignKey(d =>  d.CarWorkTypeId);

        }
    }
}
