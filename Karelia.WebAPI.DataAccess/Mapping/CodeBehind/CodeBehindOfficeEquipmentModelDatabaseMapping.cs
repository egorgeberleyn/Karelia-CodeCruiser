using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="OfficeEquipmentModel"/> to table dbo.OfficeEquipmentModel
    /// </summary>
    internal abstract class CodeBehindOfficeEquipmentModelDatabaseMapping : EntityTypeConfiguration<OfficeEquipmentModel>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindOfficeEquipmentModelDatabaseMapping()
        {
                ToTable("OfficeEquipmentModel", "dbo");
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
