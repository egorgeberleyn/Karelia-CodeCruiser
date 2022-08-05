using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="CarServicePart"/> to table dbo.CarServicePart
    /// </summary>
    internal abstract class CodeBehindCarServicePartDatabaseMapping : EntityTypeConfiguration<CarServicePart>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindCarServicePartDatabaseMapping()
        {
                ToTable("CarServicePart", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CarModelPartId)
			    .HasColumnName("CarModelPartId")
			    .IsRequired();
            Property(t => t.CarServiceId)
			    .HasColumnName("CarServiceId")
			    .IsRequired();
            Property(t => t.Quantity)
			    .HasColumnName("Quantity")
			    .IsRequired();


            HasRequired(t => t.CarModelPart)
                .WithMany()
				.HasForeignKey(d =>  d.CarModelPartId);

            HasRequired(t => t.CarService)
                .WithMany()
				.HasForeignKey(d =>  d.CarServiceId);

        }
    }
}
