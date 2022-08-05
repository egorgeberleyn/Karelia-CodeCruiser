using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysObjectClass"/> to table CCSystem.SysObjectClasses
    /// </summary>
    internal abstract class CodeBehindSysObjectClassDatabaseMapping : EntityTypeConfiguration<SysObjectClass>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysObjectClassDatabaseMapping()
        {
                ToTable("SysObjectClasses", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired();
            Property(t => t.CodeName)
			    .HasColumnName("CodeName")
			    .IsRequired();
            Property(t => t.Description)
			    .HasColumnName("Description")
			    .IsUnicode();
            Property(t => t.DisplayName)
			    .HasColumnName("DisplayName")
			    .IsRequired()
			    .IsUnicode();
        }
    }
}
