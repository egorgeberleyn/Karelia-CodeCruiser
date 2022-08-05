using System;
using System.Linq;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;



namespace Karelia.WebAPI.Contracts
{
    public interface IApiEntityManager : IEntityManager
    {
        IQueryable<SysUserPermissionsDisplayView> SysUserPermissionsDisplayViews { get; }
        IQueryable<SysOperation> SysOperations { get; }
        IQueryable<CarWorkType> CarWorkTypes { get; }
        IQueryable<SysObject> SysObjects { get; }
        IQueryable<SysOperationResult> SysOperationResults { get; }
        IQueryable<Office> Offices { get; }
        IQueryable<CarArrivalReasonType> CarArrivalReasonTypes { get; }
        IQueryable<SysResetPasswordToken> SysResetPasswordTokens { get; }
        IQueryable<SysRefreshToken> SysRefreshTokens { get; }
        IQueryable<SysRole> SysRoles { get; }
        IQueryable<SysUser> SysUsers { get; }
        IQueryable<CarServiceWork> CarServiceWorks { get; }
        IQueryable<SysRolePermission> SysRolePermissions { get; }
        IQueryable<Car> Cars { get; }
        IQueryable<SubTask> SubTasks { get; }
        IQueryable<CarModelPart> CarModelParts { get; }
        IQueryable<SysOperationLock> SysOperationLocks { get; }
        IQueryable<SysUserRole> SysUserRoles { get; }
        IQueryable<CarService> CarServices { get; }
        IQueryable<OfiiceEmployee> OfiiceEmployees { get; }
        IQueryable<SysPermission> SysPermissions { get; }
        IQueryable<SysSetting> SysSettings { get; }
        IQueryable<MainTask> MainTasks { get; }
        IQueryable<OfficeEquipment> OfficeEquipments { get; }
        IQueryable<SysInfo> SysInfos { get; }
        IQueryable<CarServicePart> CarServiceParts { get; }
        IQueryable<SysObjectType> SysObjectTypes { get; }
        IQueryable<MethodicalToolkit> MethodicalToolkits { get; }
        IQueryable<SysObjectClass> SysObjectClasses { get; }
        IQueryable<SysPermissionType> SysPermissionTypes { get; }
        IQueryable<SysSettingProperty> SysSettingProperties { get; }
        IQueryable<SysUsersDisplayView> SysUsersDisplayViews { get; }
        IQueryable<CarModel> CarModels { get; }
        IQueryable<MethodicalToolkitFile> MethodicalToolkitFiles { get; }
        IQueryable<OfficeEquipmentModel> OfficeEquipmentModels { get; }
    }
}