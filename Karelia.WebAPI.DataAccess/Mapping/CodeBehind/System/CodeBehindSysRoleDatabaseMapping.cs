using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping.CodeBehind
{
    /// <summary>
    /// Database mapping for <see cref="SysRole"/> to table CCSystem.Roles
    /// </summary>
    internal abstract class CodeBehindSysRoleDatabaseMapping : EntityTypeConfiguration<SysRole>
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        protected CodeBehindSysRoleDatabaseMapping()
        {
                ToTable("Roles", "CCSystem");
            HasKey(t => t.Id);

            Property(t => t.Id)
			    .HasColumnName("Id")
			    .IsRequired()
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Description)
			    .HasColumnName("Description")
			    .IsUnicode();
            Property(t => t.IsOwnByUser)
			    .HasColumnName("IsOwnByUser")
			    .IsRequired();
            Property(t => t.IsSystem)
			    .HasColumnName("IsSystem")
			    .IsRequired();
            Property(t => t.Name)
			    .HasColumnName("Name")
			    .IsRequired()
			    .IsUnicode();
            Property(t => t.OwnerUserID)
			    .HasColumnName("OwnerUserID");


            HasOptional(t => t.OwnerUser)
                .WithMany()
				.HasForeignKey(d =>  d.OwnerUserID);

        }
    }
}
