using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysPermission"/> to table CCSystem.Permissions
    /// </summary>
    internal abstract class CodeBehindSysPermissionDatabaseMapping : EntityTypeConfiguration<SysPermission>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysPermissionDatabaseMapping()
        {
                ToTable("Permissions", "CCSystem");
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
			    .IsUnicode();
            Property(t => t.Guid)
			    .HasColumnName("Guid")
			    .IsRequired();
            Property(t => t.ObjectId)
			    .HasColumnName("ObjectId")
			    .IsRequired();
            Property(t => t.Type)
			    .HasColumnName("Type")
			    .IsRequired();


            HasRequired(t => t.SysPermissionType)
                .WithMany()
				.HasForeignKey(d =>  d.Type);

            HasRequired(t => t.SysObject)
                .WithMany()
				.HasForeignKey(d =>  d.ObjectId);

        }
    }
}
