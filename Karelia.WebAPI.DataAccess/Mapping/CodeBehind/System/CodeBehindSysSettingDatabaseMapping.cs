using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysSetting"/> to table CCSystem.Settings
    /// </summary>
    internal abstract class CodeBehindSysSettingDatabaseMapping : EntityTypeConfiguration<SysSetting>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysSettingDatabaseMapping()
        {
                ToTable("Settings", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.SettingPropertyId)
			    .HasColumnName("SettingPropertyId")
			    .IsRequired();
            Property(t => t.StringValue)
			    .HasColumnName("Value")
			    .IsUnicode();
            Property(t => t.UserId)
			    .HasColumnName("UserId");


            HasRequired(t => t.SysSettingProperty)
                .WithMany()
				.HasForeignKey(d =>  d.SettingPropertyId);

            HasOptional(t => t.SysUser)
                .WithMany()
				.HasForeignKey(d =>  d.UserId);

        }
    }
}
