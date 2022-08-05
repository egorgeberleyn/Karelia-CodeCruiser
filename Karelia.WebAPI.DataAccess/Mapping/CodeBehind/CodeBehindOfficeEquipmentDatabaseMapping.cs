using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="OfficeEquipment"/> to table dbo.OfficeEquipment
    /// </summary>
    internal abstract class CodeBehindOfficeEquipmentDatabaseMapping : EntityTypeConfiguration<OfficeEquipment>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindOfficeEquipmentDatabaseMapping()
        {
                ToTable("OfficeEquipment", "dbo");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Description)
			    .HasColumnName("Description")
			    .IsUnicode();
            Property(t => t.InventoryNumber)
			    .HasColumnName("InventoryNumber")
			    .IsRequired()
			    .IsUnicode();
            Property(t => t.OfficeEmployeeId)
			    .HasColumnName("OfficeEmployeeId")
			    .IsRequired();
            Property(t => t.OfficeEquipmentModelId)
			    .HasColumnName("OfficeEquipmentModelId")
			    .IsRequired();
            Property(t => t.OfficeId)
			    .HasColumnName("OfficeId")
			    .IsRequired();
            Property(t => t.PlacementDate)
			    .HasColumnName("PlacementDate");
            Property(t => t.Quontity)
			    .HasColumnName("Quontity");


            HasRequired(t => t.OfficeEquipmentModel)
                .WithMany()
				.HasForeignKey(d =>  d.OfficeEquipmentModelId);

            HasRequired(t => t.Office)
                .WithMany()
				.HasForeignKey(d =>  d.OfficeId);

            HasRequired(t => t.OfiiceEmployee)
                .WithMany()
				.HasForeignKey(d =>  d.OfficeEmployeeId);

        }
    }
}
