using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="CarService"/> to table dbo.CarService
    /// </summary>
    internal abstract class CodeBehindCarServiceDatabaseMapping : EntityTypeConfiguration<CarService>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindCarServiceDatabaseMapping()
        {
                ToTable("CarService", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CarArrivalReasonTypeId)
			    .HasColumnName("CarArrivalReasonTypeId");
            Property(t => t.CarId)
			    .HasColumnName("CarId")
			    .IsRequired();
            Property(t => t.Conclusion)
			    .HasColumnName("Conclusion")
			    .IsUnicode();
            Property(t => t.Defect)
			    .HasColumnName("Defect")
			    .IsUnicode();
            Property(t => t.EndDate)
			    .HasColumnName("EndDate");
            Property(t => t.Odometer)
			    .HasColumnName("Odometer");
            Property(t => t.StartDate)
			    .HasColumnName("StartDate");


            HasOptional(t => t.CarArrivalReasonType)
                .WithMany()
				.HasForeignKey(d =>  d.CarArrivalReasonTypeId);

            HasRequired(t => t.Car)
                .WithMany()
				.HasForeignKey(d =>  d.CarId);

        }
    }
}
