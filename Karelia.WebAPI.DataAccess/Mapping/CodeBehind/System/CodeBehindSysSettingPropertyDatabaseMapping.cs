using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysSettingProperty"/> to table CCSystem.SettingProperties
    /// </summary>
    internal abstract class CodeBehindSysSettingPropertyDatabaseMapping : EntityTypeConfiguration<SysSettingProperty>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysSettingPropertyDatabaseMapping()
        {
                ToTable("SettingProperties", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.DefaultType)
			    .HasColumnName("DefaultType")
			    .IsUnicode();
            Property(t => t.Description)
			    .HasColumnName("Description")
			    .IsUnicode();
            Property(t => t.GroupName)
			    .HasColumnName("GroupName")
			    .IsUnicode();
            Property(t => t.IsManaged)
			    .HasColumnName("IsManaged")
			    .IsRequired();
            Property(t => t.IsOverridable)
			    .HasColumnName("IsOverridable")
			    .IsRequired();
            Property(t => t.Name)
			    .HasColumnName("Name")
			    .IsRequired();
            Property(t => t.UIEditorType)
			    .HasColumnName("UIEditorType")
			    .IsUnicode();
        }
    }
}
