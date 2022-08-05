using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="CarModel"/> to table dbo.CarModel
    /// </summary>
    internal abstract class CodeBehindCarModelDatabaseMapping : EntityTypeConfiguration<CarModel>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindCarModelDatabaseMapping()
        {
                ToTable("CarModel", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FuelConsumption)
			    .HasColumnName("FuelConsumption");
            Property(t => t.Name)
			    .HasColumnName("Name")
			    .IsRequired()
			    .IsUnicode();
        }
    }
}
