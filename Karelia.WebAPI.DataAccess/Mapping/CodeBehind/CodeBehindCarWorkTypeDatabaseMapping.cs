using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="CarWorkType"/> to table dbo.CarWorkType
    /// </summary>
    internal abstract class CodeBehindCarWorkTypeDatabaseMapping : EntityTypeConfiguration<CarWorkType>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindCarWorkTypeDatabaseMapping()
        {
                ToTable("CarWorkType", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name)
			    .HasColumnName("Name")
			    .IsUnicode();
        }
    }
}
