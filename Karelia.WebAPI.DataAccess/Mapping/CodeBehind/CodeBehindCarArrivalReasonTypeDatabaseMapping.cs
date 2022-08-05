using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="CarArrivalReasonType"/> to table dbo.CarArrivalReasonType
    /// </summary>
    internal abstract class CodeBehindCarArrivalReasonTypeDatabaseMapping : EntityTypeConfiguration<CarArrivalReasonType>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindCarArrivalReasonTypeDatabaseMapping()
        {
                ToTable("CarArrivalReasonType", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name)
			    .HasColumnName("Name")
			    .IsRequired()
			    .IsUnicode();
        }
    }
}
