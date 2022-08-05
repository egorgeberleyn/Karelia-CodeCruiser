using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysObject"/> to table CCSystem.SysObjects
    /// </summary>
    internal abstract class CodeBehindSysObjectDatabaseMapping : EntityTypeConfiguration<SysObject>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysObjectDatabaseMapping()
        {
                ToTable("SysObjects", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired();
            Property(t => t.ClassId)
			    .HasColumnName("ClassId")
			    .IsRequired();
            Property(t => t.CodeName)
			    .HasColumnName("CodeName")
			    .IsRequired();
            Property(t => t.DbFieldId)
			    .HasColumnName("DbFieldId");
            Property(t => t.DbObjectId)
			    .HasColumnName("DbObjectId");
            Property(t => t.Description)
			    .HasColumnName("Description")
			    .IsUnicode();
            Property(t => t.DisplayName)
			    .HasColumnName("DisplayName")
			    .IsRequired()
			    .IsUnicode();
            Property(t => t.Guid)
			    .HasColumnName("Guid")
			    .IsRequired();
            Property(t => t.ParentId)
			    .HasColumnName("ParentId")
			    .IsRequired();


            HasRequired(t => t.SysObjectClass)
                .WithMany()
				.HasForeignKey(d =>  d.ClassId);

        }
    }
}
