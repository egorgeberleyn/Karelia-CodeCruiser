using System;
using BusinessFramework.WebAPI.Contracts.Data;
using FutureTechnologies.DI.Contracts;
using Karelia.WebAPI.Contracts.Repositories;
using Karelia.WebAPI.DataAccess;
using Karelia.WebAPI.DataAccess.Repositories;


namespace Karelia.WebApiServer
{
    internal static partial class DependencyInjectionConfig
    {
        public static void ConfigureRepositories(IServerContainerRegistrator registrator)
        {
            registrator.PerRequest<IFileLinkRepository, FileLinkRepository>();
            
            registrator.PerRequest<ISysUserPermissionsDisplayViewRepository, SysUserPermissionsDisplayViewRepository>();
            registrator.PerRequest<ISysOperationRepository, SysOperationRepository>();
            registrator.PerRequest<ICarWorkTypeRepository, CarWorkTypeRepository>();
            registrator.PerRequest<ISysObjectRepository, SysObjectRepository>();
            registrator.PerRequest<ISysOperationResultRepository, SysOperationResultRepository>();
            registrator.PerRequest<IOfficeRepository, OfficeRepository>();
            registrator.PerRequest<ICarArrivalReasonTypeRepository, CarArrivalReasonTypeRepository>();
            registrator.PerRequest<ISysResetPasswordTokenRepository, SysResetPasswordTokenRepository>();
            registrator.PerRequest<ISysRefreshTokenRepository, SysRefreshTokenRepository>();
            registrator.PerRequest<ISysRoleRepository, SysRoleRepository>();
            registrator.PerRequest<ISysUserRepository, SysUserRepository>();
            registrator.PerRequest<ICarServiceWorkRepository, CarServiceWorkRepository>();
            registrator.PerRequest<ISysRolePermissionRepository, SysRolePermissionRepository>();
            registrator.PerRequest<ICarRepository, CarRepository>();
            registrator.PerRequest<ISubTaskRepository, SubTaskRepository>();
            registrator.PerRequest<ICarModelPartRepository, CarModelPartRepository>();
            registrator.PerRequest<ISysOperationLockRepository, SysOperationLockRepository>();
            registrator.PerRequest<ISysUserRoleRepository, SysUserRoleRepository>();
            registrator.PerRequest<ICarServiceRepository, CarServiceRepository>();
            registrator.PerRequest<IOfiiceEmployeeRepository, OfiiceEmployeeRepository>();
            registrator.PerRequest<ISysPermissionRepository, SysPermissionRepository>();
            registrator.PerRequest<ISysSettingRepository, SysSettingRepository>();
            registrator.PerRequest<IMainTaskRepository, MainTaskRepository>();
            registrator.PerRequest<IOfficeEquipmentRepository, OfficeEquipmentRepository>();
            registrator.PerRequest<ISysInfoRepository, SysInfoRepository>();
            registrator.PerRequest<ICarServicePartRepository, CarServicePartRepository>();
            registrator.PerRequest<ISysObjectTypeRepository, SysObjectTypeRepository>();
            registrator.PerRequest<IMethodicalToolkitRepository, MethodicalToolkitRepository>();
            registrator.PerRequest<ISysObjectClassRepository, SysObjectClassRepository>();
            registrator.PerRequest<ISysPermissionTypeRepository, SysPermissionTypeRepository>();
            registrator.PerRequest<ISysSettingPropertyRepository, SysSettingPropertyRepository>();
            registrator.PerRequest<ISysUsersDisplayViewRepository, SysUsersDisplayViewRepository>();
            registrator.PerRequest<ICarModelRepository, CarModelRepository>();
            registrator.PerRequest<IMethodicalToolkitFileRepository, MethodicalToolkitFileRepository>();
            registrator.PerRequest<IOfficeEquipmentModelRepository, OfficeEquipmentModelRepository>();
            registrator.PerRequest<IMainTaskQueryRepository, MainTaskQueryRepository>();
            registrator.PerRequest<ICarServicePartQueryRepository, CarServicePartQueryRepository>();
            registrator.PerRequest<ICarServiceQueryRepository, CarServiceQueryRepository>();
            registrator.PerRequest<ISubTaskQueryRepository, SubTaskQueryRepository>();
            registrator.PerRequest<ICarServiceWorkQueryRepository, CarServiceWorkQueryRepository>();
            registrator.PerRequest<IOfficeEquipmentQueryRepository, OfficeEquipmentQueryRepository>();
            registrator.PerRequest<ICarQueryRepository, CarQueryRepository>();
        }
    }
}