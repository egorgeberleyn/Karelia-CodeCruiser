using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="Car"/> to table dbo.Car
    /// </summary>
    internal abstract class CodeBehindCarDatabaseMapping : EntityTypeConfiguration<Car>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindCarDatabaseMapping()
        {
                ToTable("Car", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CarModelId)
			    .HasColumnName("CarModelId")
			    .IsRequired();
            Property(t => t.Description)
			    .HasColumnName("Description")
			    .IsUnicode();
            Property(t => t.Number)
			    .HasColumnName("Number")
			    .IsRequired()
			    .IsUnicode();


            HasRequired(t => t.CarModel)
                .WithMany()
				.HasForeignKey(d =>  d.CarModelId);

        }
    }
}
