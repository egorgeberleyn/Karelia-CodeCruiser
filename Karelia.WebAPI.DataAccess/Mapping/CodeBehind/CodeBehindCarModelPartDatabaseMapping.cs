using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="CarModelPart"/> to table dbo.CarModelPart
    /// </summary>
    internal abstract class CodeBehindCarModelPartDatabaseMapping : EntityTypeConfiguration<CarModelPart>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindCarModelPartDatabaseMapping()
        {
                ToTable("CarModelPart", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CarModelId)
			    .HasColumnName("CarModelId")
			    .IsRequired();
            Property(t => t.Name)
			    .HasColumnName("Name")
			    .IsRequired()
			    .IsUnicode();
            Property(t => t.Price)
			    .HasColumnName("Price")
			    .HasPrecision(18, 2);


            HasRequired(t => t.CarModel)
                .WithMany()
				.HasForeignKey(d =>  d.CarModelId);

        }
    }
}
