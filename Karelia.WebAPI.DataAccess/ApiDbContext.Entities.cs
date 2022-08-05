using System.Linq;
using BusinessFramework.WebAPI.Contracts.Files;
using Karelia.WebAPI.Contracts.DataObjects;



namespace Karelia.WebAPI.DataAccess
{
    partial class ApiDbContext
    {

        /// <summary>
        /// Set of <see cref="FileLink"/> objects
        /// </summary>
        public IQueryable<FileLink> FileLinks
        {
            get { return GetSet<FileLink>(); }
        }
        /// <summary>
        /// Set of <see cref="SysUserPermissionsDisplayView"/> objects
        /// </summary>
        public IQueryable<SysUserPermissionsDisplayView> SysUserPermissionsDisplayViews
        {
            get { return GetSet<SysUserPermissionsDisplayView>(); }
        }
        /// <summary>
        /// Set of <see cref="SysOperation"/> objects
        /// </summary>
        public IQueryable<SysOperation> SysOperations
        {
            get { return GetSet<SysOperation>(); }
        }
        /// <summary>
        /// Set of <see cref="CarWorkType"/> objects
        /// </summary>
        public IQueryable<CarWorkType> CarWorkTypes
        {
            get { return GetSet<CarWorkType>(); }
        }
        /// <summary>
        /// Set of <see cref="SysObject"/> objects
        /// </summary>
        public IQueryable<SysObject> SysObjects
        {
            get { return GetSet<SysObject>(); }
        }
        /// <summary>
        /// Set of <see cref="SysOperationResult"/> objects
        /// </summary>
        public IQueryable<SysOperationResult> SysOperationResults
        {
            get { return GetSet<SysOperationResult>(); }
        }
        /// <summary>
        /// Set of <see cref="Office"/> objects
        /// </summary>
        public IQueryable<Office> Offices
        {
            get { return GetSet<Office>(); }
        }
        /// <summary>
        /// Set of <see cref="CarArrivalReasonType"/> objects
        /// </summary>
        public IQueryable<CarArrivalReasonType> CarArrivalReasonTypes
        {
            get { return GetSet<CarArrivalReasonType>(); }
        }
        /// <summary>
        /// Set of <see cref="SysResetPasswordToken"/> objects
        /// </summary>
        public IQueryable<SysResetPasswordToken> SysResetPasswordTokens
        {
            get { return GetSet<SysResetPasswordToken>(); }
        }
        /// <summary>
        /// Set of <see cref="SysRefreshToken"/> objects
        /// </summary>
        public IQueryable<SysRefreshToken> SysRefreshTokens
        {
            get { return GetSet<SysRefreshToken>(); }
        }
        /// <summary>
        /// Set of <see cref="SysRole"/> objects
        /// </summary>
        public IQueryable<SysRole> SysRoles
        {
            get { return GetSet<SysRole>(); }
        }
        /// <summary>
        /// Set of <see cref="SysUser"/> objects
        /// </summary>
        public IQueryable<SysUser> SysUsers
        {
            get { return GetSet<SysUser>(); }
        }
        /// <summary>
        /// Set of <see cref="CarServiceWork"/> objects
        /// </summary>
        public IQueryable<CarServiceWork> CarServiceWorks
        {
            get { return GetSet<CarServiceWork>(); }
        }
        /// <summary>
        /// Set of <see cref="SysRolePermission"/> objects
        /// </summary>
        public IQueryable<SysRolePermission> SysRolePermissions
        {
            get { return GetSet<SysRolePermission>(); }
        }
        /// <summary>
        /// Set of <see cref="Car"/> objects
        /// </summary>
        public IQueryable<Car> Cars
        {
            get { return GetSet<Car>(); }
        }
        /// <summary>
        /// Set of <see cref="SubTask"/> objects
        /// </summary>
        public IQueryable<SubTask> SubTasks
        {
            get { return GetSet<SubTask>(); }
        }
        /// <summary>
        /// Set of <see cref="CarModelPart"/> objects
        /// </summary>
        public IQueryable<CarModelPart> CarModelParts
        {
            get { return GetSet<CarModelPart>(); }
        }
        /// <summary>
        /// Set of <see cref="SysOperationLock"/> objects
        /// </summary>
        public IQueryable<SysOperationLock> SysOperationLocks
        {
            get { return GetSet<SysOperationLock>(); }
        }
        /// <summary>
        /// Set of <see cref="SysUserRole"/> objects
        /// </summary>
        public IQueryable<SysUserRole> SysUserRoles
        {
            get { return GetSet<SysUserRole>(); }
        }
        /// <summary>
        /// Set of <see cref="CarService"/> objects
        /// </summary>
        public IQueryable<CarService> CarServices
        {
            get { return GetSet<CarService>(); }
        }
        /// <summary>
        /// Set of <see cref="OfiiceEmployee"/> objects
        /// </summary>
        public IQueryable<OfiiceEmployee> OfiiceEmployees
        {
            get { return GetSet<OfiiceEmployee>(); }
        }
        /// <summary>
        /// Set of <see cref="SysPermission"/> objects
        /// </summary>
        public IQueryable<SysPermission> SysPermissions
        {
            get { return GetSet<SysPermission>(); }
        }
        /// <summary>
        /// Set of <see cref="SysSetting"/> objects
        /// </summary>
        public IQueryable<SysSetting> SysSettings
        {
            get { return GetSet<SysSetting>(); }
        }
        /// <summary>
        /// Set of <see cref="MainTask"/> objects
        /// </summary>
        public IQueryable<MainTask> MainTasks
        {
            get { return GetSet<MainTask>(); }
        }
        /// <summary>
        /// Set of <see cref="OfficeEquipment"/> objects
        /// </summary>
        public IQueryable<OfficeEquipment> OfficeEquipments
        {
            get { return GetSet<OfficeEquipment>(); }
        }
        /// <summary>
        /// Set of <see cref="SysInfo"/> objects
        /// </summary>
        public IQueryable<SysInfo> SysInfos
        {
            get { return GetSet<SysInfo>(); }
        }
        /// <summary>
        /// Set of <see cref="CarServicePart"/> objects
        /// </summary>
        public IQueryable<CarServicePart> CarServiceParts
        {
            get { return GetSet<CarServicePart>(); }
        }
        /// <summary>
        /// Set of <see cref="SysObjectType"/> objects
        /// </summary>
        public IQueryable<SysObjectType> SysObjectTypes
        {
            get { return GetSet<SysObjectType>(); }
        }
        /// <summary>
        /// Set of <see cref="MethodicalToolkit"/> objects
        /// </summary>
        public IQueryable<MethodicalToolkit> MethodicalToolkits
        {
            get { return GetSet<MethodicalToolkit>(); }
        }
        /// <summary>
        /// Set of <see cref="SysObjectClass"/> objects
        /// </summary>
        public IQueryable<SysObjectClass> SysObjectClasses
        {
            get { return GetSet<SysObjectClass>(); }
        }
        /// <summary>
        /// Set of <see cref="SysPermissionType"/> objects
        /// </summary>
        public IQueryable<SysPermissionType> SysPermissionTypes
        {
            get { return GetSet<SysPermissionType>(); }
        }
        /// <summary>
        /// Set of <see cref="SysSettingProperty"/> objects
        /// </summary>
        public IQueryable<SysSettingProperty> SysSettingProperties
        {
            get { return GetSet<SysSettingProperty>(); }
        }
        /// <summary>
        /// Set of <see cref="SysUsersDisplayView"/> objects
        /// </summary>
        public IQueryable<SysUsersDisplayView> SysUsersDisplayViews
        {
            get { return GetSet<SysUsersDisplayView>(); }
        }
        /// <summary>
        /// Set of <see cref="CarModel"/> objects
        /// </summary>
        public IQueryable<CarModel> CarModels
        {
            get { return GetSet<CarModel>(); }
        }
        /// <summary>
        /// Set of <see cref="MethodicalToolkitFile"/> objects
        /// </summary>
        public IQueryable<MethodicalToolkitFile> MethodicalToolkitFiles
        {
            get { return GetSet<MethodicalToolkitFile>(); }
        }
        /// <summary>
        /// Set of <see cref="OfficeEquipmentModel"/> objects
        /// </summary>
        public IQueryable<OfficeEquipmentModel> OfficeEquipmentModels
        {
            get { return GetSet<OfficeEquipmentModel>(); }
        }
    }
}