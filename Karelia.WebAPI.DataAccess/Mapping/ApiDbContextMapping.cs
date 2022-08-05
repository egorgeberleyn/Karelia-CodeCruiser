using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    internal static class ApiDbContextMapping
    {
        public static void OnModelCreating(DbModelBuilder modelBuilder)
        {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.Configurations.Add(new FileLinkDatabaseMapping());

            modelBuilder.Configurations.Add(new SysUserPermissionsDisplayViewDatabaseMapping());
            modelBuilder.Configurations.Add(new SysOperationDatabaseMapping());
            modelBuilder.Configurations.Add(new CarWorkTypeDatabaseMapping());
            modelBuilder.Configurations.Add(new SysObjectDatabaseMapping());
            modelBuilder.Configurations.Add(new SysOperationResultDatabaseMapping());
            modelBuilder.Configurations.Add(new OfficeDatabaseMapping());
            modelBuilder.Configurations.Add(new CarArrivalReasonTypeDatabaseMapping());
            modelBuilder.Configurations.Add(new SysResetPasswordTokenDatabaseMapping());
            modelBuilder.Configurations.Add(new SysRefreshTokenDatabaseMapping());
            modelBuilder.Configurations.Add(new SysRoleDatabaseMapping());
            modelBuilder.Configurations.Add(new SysUserDatabaseMapping());
            modelBuilder.Configurations.Add(new CarServiceWorkDatabaseMapping());
            modelBuilder.Configurations.Add(new SysRolePermissionDatabaseMapping());
            modelBuilder.Configurations.Add(new CarDatabaseMapping());
            modelBuilder.Configurations.Add(new SubTaskDatabaseMapping());
            modelBuilder.Configurations.Add(new CarModelPartDatabaseMapping());
            modelBuilder.Configurations.Add(new SysOperationLockDatabaseMapping());
            modelBuilder.Configurations.Add(new SysUserRoleDatabaseMapping());
            modelBuilder.Configurations.Add(new CarServiceDatabaseMapping());
            modelBuilder.Configurations.Add(new OfiiceEmployeeDatabaseMapping());
            modelBuilder.Configurations.Add(new SysPermissionDatabaseMapping());
            modelBuilder.Configurations.Add(new SysSettingDatabaseMapping());
            modelBuilder.Configurations.Add(new MainTaskDatabaseMapping());
            modelBuilder.Configurations.Add(new OfficeEquipmentDatabaseMapping());
            modelBuilder.Configurations.Add(new SysInfoDatabaseMapping());
            modelBuilder.Configurations.Add(new CarServicePartDatabaseMapping());
            modelBuilder.Configurations.Add(new SysObjectTypeDatabaseMapping());
            modelBuilder.Configurations.Add(new MethodicalToolkitDatabaseMapping());
            modelBuilder.Configurations.Add(new SysObjectClassDatabaseMapping());
            modelBuilder.Configurations.Add(new SysPermissionTypeDatabaseMapping());
            modelBuilder.Configurations.Add(new SysSettingPropertyDatabaseMapping());
            modelBuilder.Configurations.Add(new SysUsersDisplayViewDatabaseMapping());
            modelBuilder.Configurations.Add(new CarModelDatabaseMapping());
            modelBuilder.Configurations.Add(new MethodicalToolkitFileDatabaseMapping());
            modelBuilder.Configurations.Add(new OfficeEquipmentModelDatabaseMapping());
	
        }
    }
}