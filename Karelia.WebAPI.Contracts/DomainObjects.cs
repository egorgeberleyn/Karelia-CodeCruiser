using System;
using BusinessFramework.WebAPI.Contracts.Files;
using BusinessFramework.WebAPI.Contracts.Metadata;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.Contracts
{
    /// <summary>
    ///     Domain objects
    /// </summary>
    public static class DomainObjects
    {
        public static readonly CarDomainObject Car = new CarDomainObject();
        public static readonly CarArrivalReasonTypeDomainObject CarArrivalReasonType = new CarArrivalReasonTypeDomainObject();
        public static readonly CarModelDomainObject CarModel = new CarModelDomainObject();
        public static readonly CarModelPartDomainObject CarModelPart = new CarModelPartDomainObject();
        public static readonly CarQueryDomainObject CarQuery = new CarQueryDomainObject();
        public static readonly CarServiceDomainObject CarService = new CarServiceDomainObject();
        public static readonly CarServicePartDomainObject CarServicePart = new CarServicePartDomainObject();
        public static readonly CarServicePartQueryDomainObject CarServicePartQuery = new CarServicePartQueryDomainObject();
        public static readonly CarServiceQueryDomainObject CarServiceQuery = new CarServiceQueryDomainObject();
        public static readonly CarServiceWorkDomainObject CarServiceWork = new CarServiceWorkDomainObject();
        public static readonly CarServiceWorkQueryDomainObject CarServiceWorkQuery = new CarServiceWorkQueryDomainObject();
        public static readonly CarWorkTypeDomainObject CarWorkType = new CarWorkTypeDomainObject();
        public static readonly MainTaskDomainObject MainTask = new MainTaskDomainObject();
        public static readonly MainTaskQueryDomainObject MainTaskQuery = new MainTaskQueryDomainObject();
        public static readonly MethodicalToolkitDomainObject MethodicalToolkit = new MethodicalToolkitDomainObject();
        public static readonly MethodicalToolkitFileDomainObject MethodicalToolkitFile = new MethodicalToolkitFileDomainObject();
        public static readonly OfficeDomainObject Office = new OfficeDomainObject();
        public static readonly OfficeEquipmentDomainObject OfficeEquipment = new OfficeEquipmentDomainObject();
        public static readonly OfficeEquipmentModelDomainObject OfficeEquipmentModel = new OfficeEquipmentModelDomainObject();
        public static readonly OfficeEquipmentQueryDomainObject OfficeEquipmentQuery = new OfficeEquipmentQueryDomainObject();
        public static readonly OfiiceEmployeeDomainObject OfiiceEmployee = new OfiiceEmployeeDomainObject();
        public static readonly SubTaskDomainObject SubTask = new SubTaskDomainObject();
        public static readonly SubTaskQueryDomainObject SubTaskQuery = new SubTaskQueryDomainObject();
        public static readonly SysInfoDomainObject SysInfo = new SysInfoDomainObject();
        public static readonly SysObjectDomainObject SysObject = new SysObjectDomainObject();
        public static readonly SysObjectClassDomainObject SysObjectClass = new SysObjectClassDomainObject();
        public static readonly SysObjectTypeDomainObject SysObjectType = new SysObjectTypeDomainObject();
        public static readonly SysOperationDomainObject SysOperation = new SysOperationDomainObject();
        public static readonly SysOperationLockDomainObject SysOperationLock = new SysOperationLockDomainObject();
        public static readonly SysOperationResultDomainObject SysOperationResult = new SysOperationResultDomainObject();
        public static readonly SysPermissionDomainObject SysPermission = new SysPermissionDomainObject();
        public static readonly SysPermissionTypeDomainObject SysPermissionType = new SysPermissionTypeDomainObject();
        public static readonly SysRefreshTokenDomainObject SysRefreshToken = new SysRefreshTokenDomainObject();
        public static readonly SysResetPasswordTokenDomainObject SysResetPasswordToken = new SysResetPasswordTokenDomainObject();
        public static readonly SysRoleDomainObject SysRole = new SysRoleDomainObject();
        public static readonly SysRolePermissionDomainObject SysRolePermission = new SysRolePermissionDomainObject();
        public static readonly SysSettingDomainObject SysSetting = new SysSettingDomainObject();
        public static readonly SysSettingPropertyDomainObject SysSettingProperty = new SysSettingPropertyDomainObject();
        public static readonly SysUserDomainObject SysUser = new SysUserDomainObject();
        public static readonly SysUserPermissionsDisplayViewDomainObject SysUserPermissionsDisplayView = new SysUserPermissionsDisplayViewDomainObject();
        public static readonly SysUserRoleDomainObject SysUserRole = new SysUserRoleDomainObject();
        public static readonly SysUsersDisplayViewDomainObject SysUsersDisplayView = new SysUsersDisplayViewDomainObject();
        public static readonly DomainMetadataDictionary ObjResolver = new DomainMetadataDictionary(Car, CarArrivalReasonType, CarModel, CarModelPart, CarQuery, CarService, CarServicePart, CarServicePartQuery, CarServiceQuery, CarServiceWork, CarServiceWorkQuery, CarWorkType, MainTask, MainTaskQuery, MethodicalToolkit, MethodicalToolkitFile, Office, OfficeEquipment, OfficeEquipmentModel, OfficeEquipmentQuery, OfiiceEmployee, SubTask, SubTaskQuery, SysInfo, SysObject, SysObjectClass, SysObjectType, SysOperation, SysOperationLock, SysOperationResult, SysPermission, SysPermissionType, SysRefreshToken, SysResetPasswordToken, SysRole, SysRolePermission, SysSetting, SysSettingProperty, SysUser, SysUserPermissionsDisplayView, SysUserRole, SysUsersDisplayView);
    }
    


    //--
    #region Car

    public sealed class CarDomainObject : DomainObject<Car, CarDomainObject>
    {
        public CarDomainObject()
            : base("Car", DomainObjectKeys.Car, 4, false)
        {
            CarModelId = AddProperty(new DomainProperty<int, Car, CarDomainObject>("CarModelId", DomainObjectPropertyKeys.Car.CarModelId, this, false, false));
            Description = AddProperty(new DomainProperty<string, Car, CarDomainObject>("Description", DomainObjectPropertyKeys.Car.Description, this, false, false));
            Id = AddProperty(new DomainProperty<int, Car, CarDomainObject>("Id", DomainObjectPropertyKeys.Car.Id, this, false, false));
            Number = AddProperty(new DomainProperty<string, Car, CarDomainObject>("Number", DomainObjectPropertyKeys.Car.Number, this, false, false));
        }

        
        public DomainProperty<int, Car, CarDomainObject> CarModelId { get; private set; }

        public DomainProperty<string, Car, CarDomainObject> Description { get; private set; }

        public DomainProperty<int, Car, CarDomainObject> Id { get; private set; }

        public DomainProperty<string, Car, CarDomainObject> Number { get; private set; }
    }
    #endregion
    #region CarArrivalReasonType

    public sealed class CarArrivalReasonTypeDomainObject : DomainObject<CarArrivalReasonType, CarArrivalReasonTypeDomainObject>
    {
        public CarArrivalReasonTypeDomainObject()
            : base("CarArrivalReasonType", DomainObjectKeys.CarArrivalReasonType, 2, false)
        {
            Id = AddProperty(new DomainProperty<int, CarArrivalReasonType, CarArrivalReasonTypeDomainObject>("Id", DomainObjectPropertyKeys.CarArrivalReasonType.Id, this, false, false));
            Name = AddProperty(new DomainProperty<string, CarArrivalReasonType, CarArrivalReasonTypeDomainObject>("Name", DomainObjectPropertyKeys.CarArrivalReasonType.Name, this, false, false));
        }

        
        public DomainProperty<int, CarArrivalReasonType, CarArrivalReasonTypeDomainObject> Id { get; private set; }

        public DomainProperty<string, CarArrivalReasonType, CarArrivalReasonTypeDomainObject> Name { get; private set; }
    }
    #endregion
    #region CarModel

    public sealed class CarModelDomainObject : DomainObject<CarModel, CarModelDomainObject>
    {
        public CarModelDomainObject()
            : base("CarModel", DomainObjectKeys.CarModel, 3, false)
        {
            FuelConsumption = AddProperty(new DomainProperty<double?, CarModel, CarModelDomainObject>("FuelConsumption", DomainObjectPropertyKeys.CarModel.FuelConsumption, this, false, false));
            Id = AddProperty(new DomainProperty<int, CarModel, CarModelDomainObject>("Id", DomainObjectPropertyKeys.CarModel.Id, this, false, false));
            Name = AddProperty(new DomainProperty<string, CarModel, CarModelDomainObject>("Name", DomainObjectPropertyKeys.CarModel.Name, this, false, false));
        }

        
        public DomainProperty<double?, CarModel, CarModelDomainObject> FuelConsumption { get; private set; }

        public DomainProperty<int, CarModel, CarModelDomainObject> Id { get; private set; }

        public DomainProperty<string, CarModel, CarModelDomainObject> Name { get; private set; }
    }
    #endregion
    #region CarModelPart

    public sealed class CarModelPartDomainObject : DomainObject<CarModelPart, CarModelPartDomainObject>
    {
        public CarModelPartDomainObject()
            : base("CarModelPart", DomainObjectKeys.CarModelPart, 4, false)
        {
            CarModelId = AddProperty(new DomainProperty<int, CarModelPart, CarModelPartDomainObject>("CarModelId", DomainObjectPropertyKeys.CarModelPart.CarModelId, this, false, false));
            Id = AddProperty(new DomainProperty<int, CarModelPart, CarModelPartDomainObject>("Id", DomainObjectPropertyKeys.CarModelPart.Id, this, false, false));
            Name = AddProperty(new DomainProperty<string, CarModelPart, CarModelPartDomainObject>("Name", DomainObjectPropertyKeys.CarModelPart.Name, this, false, false));
            Price = AddProperty(new DomainProperty<decimal?, CarModelPart, CarModelPartDomainObject>("Price", DomainObjectPropertyKeys.CarModelPart.Price, this, false, false));
        }

        
        public DomainProperty<int, CarModelPart, CarModelPartDomainObject> CarModelId { get; private set; }

        public DomainProperty<int, CarModelPart, CarModelPartDomainObject> Id { get; private set; }

        public DomainProperty<string, CarModelPart, CarModelPartDomainObject> Name { get; private set; }

        public DomainProperty<decimal?, CarModelPart, CarModelPartDomainObject> Price { get; private set; }
    }
    #endregion
    #region CarQuery

    public sealed class CarQueryDomainObject : DomainObject<CarQuery, CarQueryDomainObject>
    {
        public CarQueryDomainObject()
            : base("CarQuery", DomainObjectKeys.CarQuery, 6, false)
        {
            CarModel_FuelConsumption = AddProperty(new DomainProperty<double?, CarQuery, CarQueryDomainObject>("CarModel_FuelConsumption", DomainObjectPropertyKeys.CarQuery.CarModel_FuelConsumption, this, false, false));
            CarModel_Name = AddProperty(new DomainProperty<string, CarQuery, CarQueryDomainObject>("CarModel_Name", DomainObjectPropertyKeys.CarQuery.CarModel_Name, this, false, false));
            CarModelId = AddProperty(new DomainProperty<int, CarQuery, CarQueryDomainObject>("CarModelId", DomainObjectPropertyKeys.CarQuery.CarModelId, this, false, false));
            Description = AddProperty(new DomainProperty<string, CarQuery, CarQueryDomainObject>("Description", DomainObjectPropertyKeys.CarQuery.Description, this, false, false));
            Id = AddProperty(new DomainProperty<int, CarQuery, CarQueryDomainObject>("Id", DomainObjectPropertyKeys.CarQuery.Id, this, false, false));
            Number = AddProperty(new DomainProperty<string, CarQuery, CarQueryDomainObject>("Number", DomainObjectPropertyKeys.CarQuery.Number, this, false, false));
        }

        
        public DomainProperty<double?, CarQuery, CarQueryDomainObject> CarModel_FuelConsumption { get; private set; }

        public DomainProperty<string, CarQuery, CarQueryDomainObject> CarModel_Name { get; private set; }

        public DomainProperty<int, CarQuery, CarQueryDomainObject> CarModelId { get; private set; }

        public DomainProperty<string, CarQuery, CarQueryDomainObject> Description { get; private set; }

        public DomainProperty<int, CarQuery, CarQueryDomainObject> Id { get; private set; }

        public DomainProperty<string, CarQuery, CarQueryDomainObject> Number { get; private set; }
    }
    #endregion
    #region CarService

    public sealed class CarServiceDomainObject : DomainObject<CarService, CarServiceDomainObject>
    {
        public CarServiceDomainObject()
            : base("CarService", DomainObjectKeys.CarService, 8, false)
        {
            CarArrivalReasonTypeId = AddProperty(new DomainProperty<int?, CarService, CarServiceDomainObject>("CarArrivalReasonTypeId", DomainObjectPropertyKeys.CarService.CarArrivalReasonTypeId, this, false, false));
            CarId = AddProperty(new DomainProperty<int, CarService, CarServiceDomainObject>("CarId", DomainObjectPropertyKeys.CarService.CarId, this, false, false));
            Conclusion = AddProperty(new DomainProperty<string, CarService, CarServiceDomainObject>("Conclusion", DomainObjectPropertyKeys.CarService.Conclusion, this, false, false));
            Defect = AddProperty(new DomainProperty<string, CarService, CarServiceDomainObject>("Defect", DomainObjectPropertyKeys.CarService.Defect, this, false, false));
            EndDate = AddProperty(new DomainProperty<DateTime?, CarService, CarServiceDomainObject>("EndDate", DomainObjectPropertyKeys.CarService.EndDate, this, false, false));
            Id = AddProperty(new DomainProperty<int, CarService, CarServiceDomainObject>("Id", DomainObjectPropertyKeys.CarService.Id, this, false, false));
            Odometer = AddProperty(new DomainProperty<int?, CarService, CarServiceDomainObject>("Odometer", DomainObjectPropertyKeys.CarService.Odometer, this, false, false));
            StartDate = AddProperty(new DomainProperty<DateTime?, CarService, CarServiceDomainObject>("StartDate", DomainObjectPropertyKeys.CarService.StartDate, this, false, false));
        }

        
        public DomainProperty<int?, CarService, CarServiceDomainObject> CarArrivalReasonTypeId { get; private set; }

        public DomainProperty<int, CarService, CarServiceDomainObject> CarId { get; private set; }

        public DomainProperty<string, CarService, CarServiceDomainObject> Conclusion { get; private set; }

        public DomainProperty<string, CarService, CarServiceDomainObject> Defect { get; private set; }

        public DomainProperty<DateTime?, CarService, CarServiceDomainObject> EndDate { get; private set; }

        public DomainProperty<int, CarService, CarServiceDomainObject> Id { get; private set; }

        public DomainProperty<int?, CarService, CarServiceDomainObject> Odometer { get; private set; }

        public DomainProperty<DateTime?, CarService, CarServiceDomainObject> StartDate { get; private set; }
    }
    #endregion
    #region CarServicePart

    public sealed class CarServicePartDomainObject : DomainObject<CarServicePart, CarServicePartDomainObject>
    {
        public CarServicePartDomainObject()
            : base("CarServicePart", DomainObjectKeys.CarServicePart, 4, false)
        {
            CarModelPartId = AddProperty(new DomainProperty<int, CarServicePart, CarServicePartDomainObject>("CarModelPartId", DomainObjectPropertyKeys.CarServicePart.CarModelPartId, this, false, false));
            CarServiceId = AddProperty(new DomainProperty<int, CarServicePart, CarServicePartDomainObject>("CarServiceId", DomainObjectPropertyKeys.CarServicePart.CarServiceId, this, false, false));
            Id = AddProperty(new DomainProperty<int, CarServicePart, CarServicePartDomainObject>("Id", DomainObjectPropertyKeys.CarServicePart.Id, this, false, false));
            Quantity = AddProperty(new DomainProperty<int, CarServicePart, CarServicePartDomainObject>("Quantity", DomainObjectPropertyKeys.CarServicePart.Quantity, this, false, false));
        }

        
        public DomainProperty<int, CarServicePart, CarServicePartDomainObject> CarModelPartId { get; private set; }

        public DomainProperty<int, CarServicePart, CarServicePartDomainObject> CarServiceId { get; private set; }

        public DomainProperty<int, CarServicePart, CarServicePartDomainObject> Id { get; private set; }

        public DomainProperty<int, CarServicePart, CarServicePartDomainObject> Quantity { get; private set; }
    }
    #endregion
    #region CarServicePartQuery

    public sealed class CarServicePartQueryDomainObject : DomainObject<CarServicePartQuery, CarServicePartQueryDomainObject>
    {
        public CarServicePartQueryDomainObject()
            : base("CarServicePartQuery", DomainObjectKeys.CarServicePartQuery, 6, false)
        {
            CarModelPart_Name = AddProperty(new DomainProperty<string, CarServicePartQuery, CarServicePartQueryDomainObject>("CarModelPart_Name", DomainObjectPropertyKeys.CarServicePartQuery.CarModelPart_Name, this, false, false));
            CarModelPart_Price = AddProperty(new DomainProperty<decimal?, CarServicePartQuery, CarServicePartQueryDomainObject>("CarModelPart_Price", DomainObjectPropertyKeys.CarServicePartQuery.CarModelPart_Price, this, false, false));
            CarModelPartId = AddProperty(new DomainProperty<int, CarServicePartQuery, CarServicePartQueryDomainObject>("CarModelPartId", DomainObjectPropertyKeys.CarServicePartQuery.CarModelPartId, this, false, false));
            CarServiceId = AddProperty(new DomainProperty<int, CarServicePartQuery, CarServicePartQueryDomainObject>("CarServiceId", DomainObjectPropertyKeys.CarServicePartQuery.CarServiceId, this, false, false));
            Id = AddProperty(new DomainProperty<int, CarServicePartQuery, CarServicePartQueryDomainObject>("Id", DomainObjectPropertyKeys.CarServicePartQuery.Id, this, false, false));
            Quantity = AddProperty(new DomainProperty<int, CarServicePartQuery, CarServicePartQueryDomainObject>("Quantity", DomainObjectPropertyKeys.CarServicePartQuery.Quantity, this, false, false));
        }

        
        public DomainProperty<string, CarServicePartQuery, CarServicePartQueryDomainObject> CarModelPart_Name { get; private set; }

        public DomainProperty<decimal?, CarServicePartQuery, CarServicePartQueryDomainObject> CarModelPart_Price { get; private set; }

        public DomainProperty<int, CarServicePartQuery, CarServicePartQueryDomainObject> CarModelPartId { get; private set; }

        public DomainProperty<int, CarServicePartQuery, CarServicePartQueryDomainObject> CarServiceId { get; private set; }

        public DomainProperty<int, CarServicePartQuery, CarServicePartQueryDomainObject> Id { get; private set; }

        public DomainProperty<int, CarServicePartQuery, CarServicePartQueryDomainObject> Quantity { get; private set; }
    }
    #endregion
    #region CarServiceQuery

    public sealed class CarServiceQueryDomainObject : DomainObject<CarServiceQuery, CarServiceQueryDomainObject>
    {
        public CarServiceQueryDomainObject()
            : base("CarServiceQuery", DomainObjectKeys.CarServiceQuery, 9, false)
        {
            CarArrivalReasonType_Name = AddProperty(new DomainProperty<string, CarServiceQuery, CarServiceQueryDomainObject>("CarArrivalReasonType_Name", DomainObjectPropertyKeys.CarServiceQuery.CarArrivalReasonType_Name, this, false, false));
            CarArrivalReasonTypeId = AddProperty(new DomainProperty<int?, CarServiceQuery, CarServiceQueryDomainObject>("CarArrivalReasonTypeId", DomainObjectPropertyKeys.CarServiceQuery.CarArrivalReasonTypeId, this, false, false));
            CarId = AddProperty(new DomainProperty<int, CarServiceQuery, CarServiceQueryDomainObject>("CarId", DomainObjectPropertyKeys.CarServiceQuery.CarId, this, false, false));
            Conclusion = AddProperty(new DomainProperty<string, CarServiceQuery, CarServiceQueryDomainObject>("Conclusion", DomainObjectPropertyKeys.CarServiceQuery.Conclusion, this, false, false));
            Defect = AddProperty(new DomainProperty<string, CarServiceQuery, CarServiceQueryDomainObject>("Defect", DomainObjectPropertyKeys.CarServiceQuery.Defect, this, false, false));
            EndDate = AddProperty(new DomainProperty<DateTime?, CarServiceQuery, CarServiceQueryDomainObject>("EndDate", DomainObjectPropertyKeys.CarServiceQuery.EndDate, this, false, false));
            Id = AddProperty(new DomainProperty<int, CarServiceQuery, CarServiceQueryDomainObject>("Id", DomainObjectPropertyKeys.CarServiceQuery.Id, this, false, false));
            Odometer = AddProperty(new DomainProperty<int?, CarServiceQuery, CarServiceQueryDomainObject>("Odometer", DomainObjectPropertyKeys.CarServiceQuery.Odometer, this, false, false));
            StartDate = AddProperty(new DomainProperty<DateTime?, CarServiceQuery, CarServiceQueryDomainObject>("StartDate", DomainObjectPropertyKeys.CarServiceQuery.StartDate, this, false, false));
        }

        
        public DomainProperty<string, CarServiceQuery, CarServiceQueryDomainObject> CarArrivalReasonType_Name { get; private set; }

        public DomainProperty<int?, CarServiceQuery, CarServiceQueryDomainObject> CarArrivalReasonTypeId { get; private set; }

        public DomainProperty<int, CarServiceQuery, CarServiceQueryDomainObject> CarId { get; private set; }

        public DomainProperty<string, CarServiceQuery, CarServiceQueryDomainObject> Conclusion { get; private set; }

        public DomainProperty<string, CarServiceQuery, CarServiceQueryDomainObject> Defect { get; private set; }

        public DomainProperty<DateTime?, CarServiceQuery, CarServiceQueryDomainObject> EndDate { get; private set; }

        public DomainProperty<int, CarServiceQuery, CarServiceQueryDomainObject> Id { get; private set; }

        public DomainProperty<int?, CarServiceQuery, CarServiceQueryDomainObject> Odometer { get; private set; }

        public DomainProperty<DateTime?, CarServiceQuery, CarServiceQueryDomainObject> StartDate { get; private set; }
    }
    #endregion
    #region CarServiceWork

    public sealed class CarServiceWorkDomainObject : DomainObject<CarServiceWork, CarServiceWorkDomainObject>
    {
        public CarServiceWorkDomainObject()
            : base("CarServiceWork", DomainObjectKeys.CarServiceWork, 4, false)
        {
            CarServiceId = AddProperty(new DomainProperty<int, CarServiceWork, CarServiceWorkDomainObject>("CarServiceId", DomainObjectPropertyKeys.CarServiceWork.CarServiceId, this, false, false));
            CarWorkTypeId = AddProperty(new DomainProperty<int, CarServiceWork, CarServiceWorkDomainObject>("CarWorkTypeId", DomainObjectPropertyKeys.CarServiceWork.CarWorkTypeId, this, false, false));
            Comments = AddProperty(new DomainProperty<string, CarServiceWork, CarServiceWorkDomainObject>("Comments", DomainObjectPropertyKeys.CarServiceWork.Comments, this, false, false));
            Id = AddProperty(new DomainProperty<int, CarServiceWork, CarServiceWorkDomainObject>("Id", DomainObjectPropertyKeys.CarServiceWork.Id, this, false, false));
        }

        
        public DomainProperty<int, CarServiceWork, CarServiceWorkDomainObject> CarServiceId { get; private set; }

        public DomainProperty<int, CarServiceWork, CarServiceWorkDomainObject> CarWorkTypeId { get; private set; }

        public DomainProperty<string, CarServiceWork, CarServiceWorkDomainObject> Comments { get; private set; }

        public DomainProperty<int, CarServiceWork, CarServiceWorkDomainObject> Id { get; private set; }
    }
    #endregion
    #region CarServiceWorkQuery

    public sealed class CarServiceWorkQueryDomainObject : DomainObject<CarServiceWorkQuery, CarServiceWorkQueryDomainObject>
    {
        public CarServiceWorkQueryDomainObject()
            : base("CarServiceWorkQuery", DomainObjectKeys.CarServiceWorkQuery, 5, false)
        {
            CarServiceId = AddProperty(new DomainProperty<int, CarServiceWorkQuery, CarServiceWorkQueryDomainObject>("CarServiceId", DomainObjectPropertyKeys.CarServiceWorkQuery.CarServiceId, this, false, false));
            CarWorkType_Name = AddProperty(new DomainProperty<string, CarServiceWorkQuery, CarServiceWorkQueryDomainObject>("CarWorkType_Name", DomainObjectPropertyKeys.CarServiceWorkQuery.CarWorkType_Name, this, false, false));
            CarWorkTypeId = AddProperty(new DomainProperty<int, CarServiceWorkQuery, CarServiceWorkQueryDomainObject>("CarWorkTypeId", DomainObjectPropertyKeys.CarServiceWorkQuery.CarWorkTypeId, this, false, false));
            Comments = AddProperty(new DomainProperty<string, CarServiceWorkQuery, CarServiceWorkQueryDomainObject>("Comments", DomainObjectPropertyKeys.CarServiceWorkQuery.Comments, this, false, false));
            Id = AddProperty(new DomainProperty<int, CarServiceWorkQuery, CarServiceWorkQueryDomainObject>("Id", DomainObjectPropertyKeys.CarServiceWorkQuery.Id, this, false, false));
        }

        
        public DomainProperty<int, CarServiceWorkQuery, CarServiceWorkQueryDomainObject> CarServiceId { get; private set; }

        public DomainProperty<string, CarServiceWorkQuery, CarServiceWorkQueryDomainObject> CarWorkType_Name { get; private set; }

        public DomainProperty<int, CarServiceWorkQuery, CarServiceWorkQueryDomainObject> CarWorkTypeId { get; private set; }

        public DomainProperty<string, CarServiceWorkQuery, CarServiceWorkQueryDomainObject> Comments { get; private set; }

        public DomainProperty<int, CarServiceWorkQuery, CarServiceWorkQueryDomainObject> Id { get; private set; }
    }
    #endregion
    #region CarWorkType

    public sealed class CarWorkTypeDomainObject : DomainObject<CarWorkType, CarWorkTypeDomainObject>
    {
        public CarWorkTypeDomainObject()
            : base("CarWorkType", DomainObjectKeys.CarWorkType, 2, false)
        {
            Id = AddProperty(new DomainProperty<int, CarWorkType, CarWorkTypeDomainObject>("Id", DomainObjectPropertyKeys.CarWorkType.Id, this, false, false));
            Name = AddProperty(new DomainProperty<string, CarWorkType, CarWorkTypeDomainObject>("Name", DomainObjectPropertyKeys.CarWorkType.Name, this, false, false));
        }

        
        public DomainProperty<int, CarWorkType, CarWorkTypeDomainObject> Id { get; private set; }

        public DomainProperty<string, CarWorkType, CarWorkTypeDomainObject> Name { get; private set; }
    }
    #endregion
    #region MainTask

    public sealed class MainTaskDomainObject : DomainObject<MainTask, MainTaskDomainObject>
    {
        public MainTaskDomainObject()
            : base("MainTask", DomainObjectKeys.MainTask, 7, false)
        {
            Comments = AddProperty(new DomainProperty<string, MainTask, MainTaskDomainObject>("Comments", DomainObjectPropertyKeys.MainTask.Comments, this, false, false));
            CreationDate = AddProperty(new DomainProperty<DateTime?, MainTask, MainTaskDomainObject>("CreationDate", DomainObjectPropertyKeys.MainTask.CreationDate, this, false, false));
            EmployeeId = AddProperty(new DomainProperty<int, MainTask, MainTaskDomainObject>("EmployeeId", DomainObjectPropertyKeys.MainTask.EmployeeId, this, false, false));
            EndDate = AddProperty(new DomainProperty<DateTime?, MainTask, MainTaskDomainObject>("EndDate", DomainObjectPropertyKeys.MainTask.EndDate, this, false, false));
            Id = AddProperty(new DomainProperty<int, MainTask, MainTaskDomainObject>("Id", DomainObjectPropertyKeys.MainTask.Id, this, false, false));
            IsCompleted = AddProperty(new DomainProperty<bool, MainTask, MainTaskDomainObject>("IsCompleted", DomainObjectPropertyKeys.MainTask.IsCompleted, this, false, false));
            Name = AddProperty(new DomainProperty<string, MainTask, MainTaskDomainObject>("Name", DomainObjectPropertyKeys.MainTask.Name, this, false, false));
        }

        
        public DomainProperty<string, MainTask, MainTaskDomainObject> Comments { get; private set; }

        public DomainProperty<DateTime?, MainTask, MainTaskDomainObject> CreationDate { get; private set; }

        public DomainProperty<int, MainTask, MainTaskDomainObject> EmployeeId { get; private set; }

        public DomainProperty<DateTime?, MainTask, MainTaskDomainObject> EndDate { get; private set; }

        public DomainProperty<int, MainTask, MainTaskDomainObject> Id { get; private set; }

        public DomainProperty<bool, MainTask, MainTaskDomainObject> IsCompleted { get; private set; }

        public DomainProperty<string, MainTask, MainTaskDomainObject> Name { get; private set; }
    }
    #endregion
    #region MainTaskQuery

    public sealed class MainTaskQueryDomainObject : DomainObject<MainTaskQuery, MainTaskQueryDomainObject>
    {
        public MainTaskQueryDomainObject()
            : base("MainTaskQuery", DomainObjectKeys.MainTaskQuery, 8, false)
        {
            Comments = AddProperty(new DomainProperty<string, MainTaskQuery, MainTaskQueryDomainObject>("Comments", DomainObjectPropertyKeys.MainTaskQuery.Comments, this, false, false));
            CreationDate = AddProperty(new DomainProperty<DateTime?, MainTaskQuery, MainTaskQueryDomainObject>("CreationDate", DomainObjectPropertyKeys.MainTaskQuery.CreationDate, this, false, false));
            Employee_Name = AddProperty(new DomainProperty<string, MainTaskQuery, MainTaskQueryDomainObject>("Employee_Name", DomainObjectPropertyKeys.MainTaskQuery.Employee_Name, this, false, false));
            EmployeeId = AddProperty(new DomainProperty<int, MainTaskQuery, MainTaskQueryDomainObject>("EmployeeId", DomainObjectPropertyKeys.MainTaskQuery.EmployeeId, this, false, false));
            EndDate = AddProperty(new DomainProperty<DateTime?, MainTaskQuery, MainTaskQueryDomainObject>("EndDate", DomainObjectPropertyKeys.MainTaskQuery.EndDate, this, false, false));
            Id = AddProperty(new DomainProperty<int, MainTaskQuery, MainTaskQueryDomainObject>("Id", DomainObjectPropertyKeys.MainTaskQuery.Id, this, false, false));
            IsCompleted = AddProperty(new DomainProperty<bool, MainTaskQuery, MainTaskQueryDomainObject>("IsCompleted", DomainObjectPropertyKeys.MainTaskQuery.IsCompleted, this, false, false));
            Name = AddProperty(new DomainProperty<string, MainTaskQuery, MainTaskQueryDomainObject>("Name", DomainObjectPropertyKeys.MainTaskQuery.Name, this, false, false));
        }

        
        public DomainProperty<string, MainTaskQuery, MainTaskQueryDomainObject> Comments { get; private set; }

        public DomainProperty<DateTime?, MainTaskQuery, MainTaskQueryDomainObject> CreationDate { get; private set; }

        public DomainProperty<string, MainTaskQuery, MainTaskQueryDomainObject> Employee_Name { get; private set; }

        public DomainProperty<int, MainTaskQuery, MainTaskQueryDomainObject> EmployeeId { get; private set; }

        public DomainProperty<DateTime?, MainTaskQuery, MainTaskQueryDomainObject> EndDate { get; private set; }

        public DomainProperty<int, MainTaskQuery, MainTaskQueryDomainObject> Id { get; private set; }

        public DomainProperty<bool, MainTaskQuery, MainTaskQueryDomainObject> IsCompleted { get; private set; }

        public DomainProperty<string, MainTaskQuery, MainTaskQueryDomainObject> Name { get; private set; }
    }
    #endregion
    #region MethodicalToolkit

    public sealed class MethodicalToolkitDomainObject : DomainObject<MethodicalToolkit, MethodicalToolkitDomainObject>
    {
        public MethodicalToolkitDomainObject()
            : base("MethodicalToolkit", DomainObjectKeys.MethodicalToolkit, 2, false)
        {
            Id = AddProperty(new DomainProperty<int, MethodicalToolkit, MethodicalToolkitDomainObject>("Id", DomainObjectPropertyKeys.MethodicalToolkit.Id, this, false, false));
            Name = AddProperty(new DomainProperty<string, MethodicalToolkit, MethodicalToolkitDomainObject>("Name", DomainObjectPropertyKeys.MethodicalToolkit.Name, this, false, false));
        }

        
        public DomainProperty<int, MethodicalToolkit, MethodicalToolkitDomainObject> Id { get; private set; }

        public DomainProperty<string, MethodicalToolkit, MethodicalToolkitDomainObject> Name { get; private set; }
    }
    #endregion
    #region MethodicalToolkitFile

    public sealed class MethodicalToolkitFileDomainObject : DomainObject<MethodicalToolkitFile, MethodicalToolkitFileDomainObject>
    {
        public MethodicalToolkitFileDomainObject()
            : base("MethodicalToolkitFile", DomainObjectKeys.MethodicalToolkitFile, 4, false)
        {
            Description = AddProperty(new DomainProperty<string, MethodicalToolkitFile, MethodicalToolkitFileDomainObject>("Description", DomainObjectPropertyKeys.MethodicalToolkitFile.Description, this, false, false));
            Id = AddProperty(new DomainProperty<int, MethodicalToolkitFile, MethodicalToolkitFileDomainObject>("Id", DomainObjectPropertyKeys.MethodicalToolkitFile.Id, this, false, false));
            MethodicalToolkitId = AddProperty(new DomainProperty<int, MethodicalToolkitFile, MethodicalToolkitFileDomainObject>("MethodicalToolkitId", DomainObjectPropertyKeys.MethodicalToolkitFile.MethodicalToolkitId, this, false, false));
            Name = AddProperty(new DomainProperty<string, MethodicalToolkitFile, MethodicalToolkitFileDomainObject>("Name", DomainObjectPropertyKeys.MethodicalToolkitFile.Name, this, false, false));
        }

        
        public DomainProperty<string, MethodicalToolkitFile, MethodicalToolkitFileDomainObject> Description { get; private set; }

        public DomainProperty<int, MethodicalToolkitFile, MethodicalToolkitFileDomainObject> Id { get; private set; }

        public DomainProperty<int, MethodicalToolkitFile, MethodicalToolkitFileDomainObject> MethodicalToolkitId { get; private set; }

        public DomainProperty<string, MethodicalToolkitFile, MethodicalToolkitFileDomainObject> Name { get; private set; }
    }
    #endregion
    #region Office

    public sealed class OfficeDomainObject : DomainObject<Office, OfficeDomainObject>
    {
        public OfficeDomainObject()
            : base("Office", DomainObjectKeys.Office, 2, false)
        {
            Adress = AddProperty(new DomainProperty<string, Office, OfficeDomainObject>("Adress", DomainObjectPropertyKeys.Office.Adress, this, false, false));
            Id = AddProperty(new DomainProperty<int, Office, OfficeDomainObject>("Id", DomainObjectPropertyKeys.Office.Id, this, false, false));
        }

        
        public DomainProperty<string, Office, OfficeDomainObject> Adress { get; private set; }

        public DomainProperty<int, Office, OfficeDomainObject> Id { get; private set; }
    }
    #endregion
    #region OfficeEquipment

    public sealed class OfficeEquipmentDomainObject : DomainObject<OfficeEquipment, OfficeEquipmentDomainObject>
    {
        public OfficeEquipmentDomainObject()
            : base("OfficeEquipment", DomainObjectKeys.OfficeEquipment, 8, false)
        {
            Description = AddProperty(new DomainProperty<string, OfficeEquipment, OfficeEquipmentDomainObject>("Description", DomainObjectPropertyKeys.OfficeEquipment.Description, this, false, false));
            Id = AddProperty(new DomainProperty<int, OfficeEquipment, OfficeEquipmentDomainObject>("Id", DomainObjectPropertyKeys.OfficeEquipment.Id, this, false, false));
            InventoryNumber = AddProperty(new DomainProperty<string, OfficeEquipment, OfficeEquipmentDomainObject>("InventoryNumber", DomainObjectPropertyKeys.OfficeEquipment.InventoryNumber, this, false, false));
            OfficeEmployeeId = AddProperty(new DomainProperty<int, OfficeEquipment, OfficeEquipmentDomainObject>("OfficeEmployeeId", DomainObjectPropertyKeys.OfficeEquipment.OfficeEmployeeId, this, false, false));
            OfficeEquipmentModelId = AddProperty(new DomainProperty<int, OfficeEquipment, OfficeEquipmentDomainObject>("OfficeEquipmentModelId", DomainObjectPropertyKeys.OfficeEquipment.OfficeEquipmentModelId, this, false, false));
            OfficeId = AddProperty(new DomainProperty<int, OfficeEquipment, OfficeEquipmentDomainObject>("OfficeId", DomainObjectPropertyKeys.OfficeEquipment.OfficeId, this, false, false));
            PlacementDate = AddProperty(new DomainProperty<DateTime?, OfficeEquipment, OfficeEquipmentDomainObject>("PlacementDate", DomainObjectPropertyKeys.OfficeEquipment.PlacementDate, this, false, false));
            Quontity = AddProperty(new DomainProperty<int?, OfficeEquipment, OfficeEquipmentDomainObject>("Quontity", DomainObjectPropertyKeys.OfficeEquipment.Quontity, this, false, false));
        }

        
        public DomainProperty<string, OfficeEquipment, OfficeEquipmentDomainObject> Description { get; private set; }

        public DomainProperty<int, OfficeEquipment, OfficeEquipmentDomainObject> Id { get; private set; }

        public DomainProperty<string, OfficeEquipment, OfficeEquipmentDomainObject> InventoryNumber { get; private set; }

        public DomainProperty<int, OfficeEquipment, OfficeEquipmentDomainObject> OfficeEmployeeId { get; private set; }

        public DomainProperty<int, OfficeEquipment, OfficeEquipmentDomainObject> OfficeEquipmentModelId { get; private set; }

        public DomainProperty<int, OfficeEquipment, OfficeEquipmentDomainObject> OfficeId { get; private set; }

        public DomainProperty<DateTime?, OfficeEquipment, OfficeEquipmentDomainObject> PlacementDate { get; private set; }

        public DomainProperty<int?, OfficeEquipment, OfficeEquipmentDomainObject> Quontity { get; private set; }
    }
    #endregion
    #region OfficeEquipmentModel

    public sealed class OfficeEquipmentModelDomainObject : DomainObject<OfficeEquipmentModel, OfficeEquipmentModelDomainObject>
    {
        public OfficeEquipmentModelDomainObject()
            : base("OfficeEquipmentModel", DomainObjectKeys.OfficeEquipmentModel, 2, false)
        {
            Id = AddProperty(new DomainProperty<int, OfficeEquipmentModel, OfficeEquipmentModelDomainObject>("Id", DomainObjectPropertyKeys.OfficeEquipmentModel.Id, this, false, false));
            Name = AddProperty(new DomainProperty<string, OfficeEquipmentModel, OfficeEquipmentModelDomainObject>("Name", DomainObjectPropertyKeys.OfficeEquipmentModel.Name, this, false, false));
        }

        
        public DomainProperty<int, OfficeEquipmentModel, OfficeEquipmentModelDomainObject> Id { get; private set; }

        public DomainProperty<string, OfficeEquipmentModel, OfficeEquipmentModelDomainObject> Name { get; private set; }
    }
    #endregion
    #region OfficeEquipmentQuery

    public sealed class OfficeEquipmentQueryDomainObject : DomainObject<OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject>
    {
        public OfficeEquipmentQueryDomainObject()
            : base("OfficeEquipmentQuery", DomainObjectKeys.OfficeEquipmentQuery, 9, false)
        {
            Description = AddProperty(new DomainProperty<string, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject>("Description", DomainObjectPropertyKeys.OfficeEquipmentQuery.Description, this, false, false));
            Id = AddProperty(new DomainProperty<int, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject>("Id", DomainObjectPropertyKeys.OfficeEquipmentQuery.Id, this, false, false));
            InventoryNumber = AddProperty(new DomainProperty<string, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject>("InventoryNumber", DomainObjectPropertyKeys.OfficeEquipmentQuery.InventoryNumber, this, false, false));
            OfficeEquipmentModel_Name = AddProperty(new DomainProperty<string, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject>("OfficeEquipmentModel_Name", DomainObjectPropertyKeys.OfficeEquipmentQuery.OfficeEquipmentModel_Name, this, false, false));
            OfficeEquipmentModelId = AddProperty(new DomainProperty<int, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject>("OfficeEquipmentModelId", DomainObjectPropertyKeys.OfficeEquipmentQuery.OfficeEquipmentModelId, this, false, false));
            OfficeId = AddProperty(new DomainProperty<int, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject>("OfficeId", DomainObjectPropertyKeys.OfficeEquipmentQuery.OfficeId, this, false, false));
            OfiiceEmployee_Name = AddProperty(new DomainProperty<string, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject>("OfiiceEmployee_Name", DomainObjectPropertyKeys.OfficeEquipmentQuery.OfiiceEmployee_Name, this, false, false));
            PlacementDate = AddProperty(new DomainProperty<DateTime?, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject>("PlacementDate", DomainObjectPropertyKeys.OfficeEquipmentQuery.PlacementDate, this, false, false));
            Quontity = AddProperty(new DomainProperty<int?, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject>("Quontity", DomainObjectPropertyKeys.OfficeEquipmentQuery.Quontity, this, false, false));
        }

        
        public DomainProperty<string, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject> Description { get; private set; }

        public DomainProperty<int, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject> Id { get; private set; }

        public DomainProperty<string, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject> InventoryNumber { get; private set; }

        public DomainProperty<string, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject> OfficeEquipmentModel_Name { get; private set; }

        public DomainProperty<int, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject> OfficeEquipmentModelId { get; private set; }

        public DomainProperty<int, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject> OfficeId { get; private set; }

        public DomainProperty<string, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject> OfiiceEmployee_Name { get; private set; }

        public DomainProperty<DateTime?, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject> PlacementDate { get; private set; }

        public DomainProperty<int?, OfficeEquipmentQuery, OfficeEquipmentQueryDomainObject> Quontity { get; private set; }
    }
    #endregion
    #region OfiiceEmployee

    public sealed class OfiiceEmployeeDomainObject : DomainObject<OfiiceEmployee, OfiiceEmployeeDomainObject>
    {
        public OfiiceEmployeeDomainObject()
            : base("OfiiceEmployee", DomainObjectKeys.OfiiceEmployee, 3, false)
        {
            Id = AddProperty(new DomainProperty<int, OfiiceEmployee, OfiiceEmployeeDomainObject>("Id", DomainObjectPropertyKeys.OfiiceEmployee.Id, this, false, false));
            Name = AddProperty(new DomainProperty<string, OfiiceEmployee, OfiiceEmployeeDomainObject>("Name", DomainObjectPropertyKeys.OfiiceEmployee.Name, this, false, false));
            OfficeId = AddProperty(new DomainProperty<int, OfiiceEmployee, OfiiceEmployeeDomainObject>("OfficeId", DomainObjectPropertyKeys.OfiiceEmployee.OfficeId, this, false, false));
        }

        
        public DomainProperty<int, OfiiceEmployee, OfiiceEmployeeDomainObject> Id { get; private set; }

        public DomainProperty<string, OfiiceEmployee, OfiiceEmployeeDomainObject> Name { get; private set; }

        public DomainProperty<int, OfiiceEmployee, OfiiceEmployeeDomainObject> OfficeId { get; private set; }
    }
    #endregion
    #region SubTask

    public sealed class SubTaskDomainObject : DomainObject<SubTask, SubTaskDomainObject>
    {
        public SubTaskDomainObject()
            : base("SubTask", DomainObjectKeys.SubTask, 5, false)
        {
            Description = AddProperty(new DomainProperty<string, SubTask, SubTaskDomainObject>("Description", DomainObjectPropertyKeys.SubTask.Description, this, false, false));
            Id = AddProperty(new DomainProperty<int, SubTask, SubTaskDomainObject>("Id", DomainObjectPropertyKeys.SubTask.Id, this, false, false));
            Name = AddProperty(new DomainProperty<string, SubTask, SubTaskDomainObject>("Name", DomainObjectPropertyKeys.SubTask.Name, this, false, false));
            Sequence = AddProperty(new DomainProperty<int?, SubTask, SubTaskDomainObject>("Sequence", DomainObjectPropertyKeys.SubTask.Sequence, this, false, false));
            TaskId = AddProperty(new DomainProperty<int, SubTask, SubTaskDomainObject>("TaskId", DomainObjectPropertyKeys.SubTask.TaskId, this, false, false));
        }

        
        public DomainProperty<string, SubTask, SubTaskDomainObject> Description { get; private set; }

        public DomainProperty<int, SubTask, SubTaskDomainObject> Id { get; private set; }

        public DomainProperty<string, SubTask, SubTaskDomainObject> Name { get; private set; }

        public DomainProperty<int?, SubTask, SubTaskDomainObject> Sequence { get; private set; }

        public DomainProperty<int, SubTask, SubTaskDomainObject> TaskId { get; private set; }
    }
    #endregion
    #region SubTaskQuery

    public sealed class SubTaskQueryDomainObject : DomainObject<SubTaskQuery, SubTaskQueryDomainObject>
    {
        public SubTaskQueryDomainObject()
            : base("SubTaskQuery", DomainObjectKeys.SubTaskQuery, 6, false)
        {
            Description = AddProperty(new DomainProperty<string, SubTaskQuery, SubTaskQueryDomainObject>("Description", DomainObjectPropertyKeys.SubTaskQuery.Description, this, false, false));
            Id = AddProperty(new DomainProperty<int, SubTaskQuery, SubTaskQueryDomainObject>("Id", DomainObjectPropertyKeys.SubTaskQuery.Id, this, false, false));
            MainTask_Employee_Name = AddProperty(new DomainProperty<string, SubTaskQuery, SubTaskQueryDomainObject>("MainTask_Employee_Name", DomainObjectPropertyKeys.SubTaskQuery.MainTask_Employee_Name, this, false, false));
            Name = AddProperty(new DomainProperty<string, SubTaskQuery, SubTaskQueryDomainObject>("Name", DomainObjectPropertyKeys.SubTaskQuery.Name, this, false, false));
            Sequence = AddProperty(new DomainProperty<int?, SubTaskQuery, SubTaskQueryDomainObject>("Sequence", DomainObjectPropertyKeys.SubTaskQuery.Sequence, this, false, false));
            TaskId = AddProperty(new DomainProperty<int, SubTaskQuery, SubTaskQueryDomainObject>("TaskId", DomainObjectPropertyKeys.SubTaskQuery.TaskId, this, false, false));
        }

        
        public DomainProperty<string, SubTaskQuery, SubTaskQueryDomainObject> Description { get; private set; }

        public DomainProperty<int, SubTaskQuery, SubTaskQueryDomainObject> Id { get; private set; }

        public DomainProperty<string, SubTaskQuery, SubTaskQueryDomainObject> MainTask_Employee_Name { get; private set; }

        public DomainProperty<string, SubTaskQuery, SubTaskQueryDomainObject> Name { get; private set; }

        public DomainProperty<int?, SubTaskQuery, SubTaskQueryDomainObject> Sequence { get; private set; }

        public DomainProperty<int, SubTaskQuery, SubTaskQueryDomainObject> TaskId { get; private set; }
    }
    #endregion
    #region SysInfo

    public sealed class SysInfoDomainObject : DomainObject<SysInfo, SysInfoDomainObject>
    {
        public SysInfoDomainObject()
            : base("SysInfo", DomainObjectKeys.SysInfo, 3, true)
        {
            DomainVersion = AddProperty(new DomainProperty<string, SysInfo, SysInfoDomainObject>("DomainVersion", DomainObjectPropertyKeys.SysInfo.DomainVersion, this, false, true));
            LastInitialization = AddProperty(new DomainProperty<DateTime, SysInfo, SysInfoDomainObject>("LastInitialization", DomainObjectPropertyKeys.SysInfo.LastInitialization, this, false, true));
            SystemVersion = AddProperty(new DomainProperty<string, SysInfo, SysInfoDomainObject>("SystemVersion", DomainObjectPropertyKeys.SysInfo.SystemVersion, this, false, true));
        }

        
        public DomainProperty<string, SysInfo, SysInfoDomainObject> DomainVersion { get; private set; }

        public DomainProperty<DateTime, SysInfo, SysInfoDomainObject> LastInitialization { get; private set; }

        public DomainProperty<string, SysInfo, SysInfoDomainObject> SystemVersion { get; private set; }
    }
    #endregion
    #region SysObject

    public sealed class SysObjectDomainObject : DomainObject<SysObject, SysObjectDomainObject>
    {
        public SysObjectDomainObject()
            : base("SysObject", DomainObjectKeys.SysObject, 9, true)
        {
            ClassId = AddProperty(new DomainProperty<byte, SysObject, SysObjectDomainObject>("ClassId", DomainObjectPropertyKeys.SysObject.ClassId, this, false, true));
            CodeName = AddProperty(new DomainProperty<string, SysObject, SysObjectDomainObject>("CodeName", DomainObjectPropertyKeys.SysObject.CodeName, this, false, true));
            DbFieldId = AddProperty(new DomainProperty<int?, SysObject, SysObjectDomainObject>("DbFieldId", DomainObjectPropertyKeys.SysObject.DbFieldId, this, false, true));
            DbObjectId = AddProperty(new DomainProperty<int?, SysObject, SysObjectDomainObject>("DbObjectId", DomainObjectPropertyKeys.SysObject.DbObjectId, this, false, true));
            Description = AddProperty(new DomainProperty<string, SysObject, SysObjectDomainObject>("Description", DomainObjectPropertyKeys.SysObject.Description, this, false, true));
            DisplayName = AddProperty(new DomainProperty<string, SysObject, SysObjectDomainObject>("DisplayName", DomainObjectPropertyKeys.SysObject.DisplayName, this, false, true));
            Guid = AddProperty(new DomainProperty<Guid, SysObject, SysObjectDomainObject>("Guid", DomainObjectPropertyKeys.SysObject.Guid, this, false, true));
            Id = AddProperty(new DomainProperty<int, SysObject, SysObjectDomainObject>("Id", DomainObjectPropertyKeys.SysObject.Id, this, false, true));
            ParentId = AddProperty(new DomainProperty<int, SysObject, SysObjectDomainObject>("ParentId", DomainObjectPropertyKeys.SysObject.ParentId, this, false, true));
        }

        
        public DomainProperty<byte, SysObject, SysObjectDomainObject> ClassId { get; private set; }

        public DomainProperty<string, SysObject, SysObjectDomainObject> CodeName { get; private set; }

        public DomainProperty<int?, SysObject, SysObjectDomainObject> DbFieldId { get; private set; }

        public DomainProperty<int?, SysObject, SysObjectDomainObject> DbObjectId { get; private set; }

        public DomainProperty<string, SysObject, SysObjectDomainObject> Description { get; private set; }

        public DomainProperty<string, SysObject, SysObjectDomainObject> DisplayName { get; private set; }

        public DomainProperty<Guid, SysObject, SysObjectDomainObject> Guid { get; private set; }

        public DomainProperty<int, SysObject, SysObjectDomainObject> Id { get; private set; }

        public DomainProperty<int, SysObject, SysObjectDomainObject> ParentId { get; private set; }
    }
    #endregion
    #region SysObjectClass

    public sealed class SysObjectClassDomainObject : DomainObject<SysObjectClass, SysObjectClassDomainObject>
    {
        public SysObjectClassDomainObject()
            : base("SysObjectClass", DomainObjectKeys.SysObjectClass, 4, true)
        {
            CodeName = AddProperty(new DomainProperty<string, SysObjectClass, SysObjectClassDomainObject>("CodeName", DomainObjectPropertyKeys.SysObjectClass.CodeName, this, false, true));
            Description = AddProperty(new DomainProperty<string, SysObjectClass, SysObjectClassDomainObject>("Description", DomainObjectPropertyKeys.SysObjectClass.Description, this, false, true));
            DisplayName = AddProperty(new DomainProperty<string, SysObjectClass, SysObjectClassDomainObject>("DisplayName", DomainObjectPropertyKeys.SysObjectClass.DisplayName, this, false, true));
            Id = AddProperty(new DomainProperty<byte, SysObjectClass, SysObjectClassDomainObject>("Id", DomainObjectPropertyKeys.SysObjectClass.Id, this, false, true));
        }

        
        public DomainProperty<string, SysObjectClass, SysObjectClassDomainObject> CodeName { get; private set; }

        public DomainProperty<string, SysObjectClass, SysObjectClassDomainObject> Description { get; private set; }

        public DomainProperty<string, SysObjectClass, SysObjectClassDomainObject> DisplayName { get; private set; }

        public DomainProperty<byte, SysObjectClass, SysObjectClassDomainObject> Id { get; private set; }
    }
    #endregion
    #region SysObjectType

    public sealed class SysObjectTypeDomainObject : DomainObject<SysObjectType, SysObjectTypeDomainObject>
    {
        public SysObjectTypeDomainObject()
            : base("SysObjectType", DomainObjectKeys.SysObjectType, 2, true)
        {
            Id = AddProperty(new DomainProperty<int, SysObjectType, SysObjectTypeDomainObject>("Id", DomainObjectPropertyKeys.SysObjectType.Id, this, false, true));
            Name = AddProperty(new DomainProperty<string, SysObjectType, SysObjectTypeDomainObject>("Name", DomainObjectPropertyKeys.SysObjectType.Name, this, false, true));
        }

        
        public DomainProperty<int, SysObjectType, SysObjectTypeDomainObject> Id { get; private set; }

        public DomainProperty<string, SysObjectType, SysObjectTypeDomainObject> Name { get; private set; }
    }
    #endregion
    #region SysOperation

    public sealed class SysOperationDomainObject : DomainObject<SysOperation, SysOperationDomainObject>
    {
        public SysOperationDomainObject()
            : base("SysOperation", DomainObjectKeys.SysOperation, 8, true)
        {
            ActionId = AddProperty(new DomainProperty<int, SysOperation, SysOperationDomainObject>("ActionId", DomainObjectPropertyKeys.SysOperation.ActionId, this, false, true));
            Date = AddProperty(new DomainProperty<DateTime, SysOperation, SysOperationDomainObject>("Date", DomainObjectPropertyKeys.SysOperation.Date, this, false, true));
            Id = AddProperty(new DomainProperty<long, SysOperation, SysOperationDomainObject>("Id", DomainObjectPropertyKeys.SysOperation.Id, this, false, true));
            OperationDetails = AddProperty(new DomainProperty<string, SysOperation, SysOperationDomainObject>("OperationDetails", DomainObjectPropertyKeys.SysOperation.OperationDetails, this, false, true));
            OperationResultId = AddProperty(new DomainProperty<byte, SysOperation, SysOperationDomainObject>("OperationResultId", DomainObjectPropertyKeys.SysOperation.OperationResultId, this, false, true));
            Request = AddProperty(new DomainProperty<string, SysOperation, SysOperationDomainObject>("Request", DomainObjectPropertyKeys.SysOperation.Request, this, false, true));
            RequestContent = AddProperty(new DomainProperty<string, SysOperation, SysOperationDomainObject>("RequestContent", DomainObjectPropertyKeys.SysOperation.RequestContent, this, false, true));
            UserID = AddProperty(new DomainProperty<int, SysOperation, SysOperationDomainObject>("UserID", DomainObjectPropertyKeys.SysOperation.UserID, this, false, true));
        }

        
        public DomainProperty<int, SysOperation, SysOperationDomainObject> ActionId { get; private set; }

        public DomainProperty<DateTime, SysOperation, SysOperationDomainObject> Date { get; private set; }

        public DomainProperty<long, SysOperation, SysOperationDomainObject> Id { get; private set; }

        public DomainProperty<string, SysOperation, SysOperationDomainObject> OperationDetails { get; private set; }

        public DomainProperty<byte, SysOperation, SysOperationDomainObject> OperationResultId { get; private set; }

        public DomainProperty<string, SysOperation, SysOperationDomainObject> Request { get; private set; }

        public DomainProperty<string, SysOperation, SysOperationDomainObject> RequestContent { get; private set; }

        public DomainProperty<int, SysOperation, SysOperationDomainObject> UserID { get; private set; }
    }
    #endregion
    #region SysOperationLock

    public sealed class SysOperationLockDomainObject : DomainObject<SysOperationLock, SysOperationLockDomainObject>
    {
        public SysOperationLockDomainObject()
            : base("SysOperationLock", DomainObjectKeys.SysOperationLock, 7, true)
        {
            AquiredTime = AddProperty(new DomainProperty<DateTime, SysOperationLock, SysOperationLockDomainObject>("AquiredTime", DomainObjectPropertyKeys.SysOperationLock.AquiredTime, this, false, true));
            ExpirationTime = AddProperty(new DomainProperty<DateTime, SysOperationLock, SysOperationLockDomainObject>("ExpirationTime", DomainObjectPropertyKeys.SysOperationLock.ExpirationTime, this, false, true));
            MachineName = AddProperty(new DomainProperty<string, SysOperationLock, SysOperationLockDomainObject>("MachineName", DomainObjectPropertyKeys.SysOperationLock.MachineName, this, false, true));
            OperationContext = AddProperty(new DomainProperty<string, SysOperationLock, SysOperationLockDomainObject>("OperationContext", DomainObjectPropertyKeys.SysOperationLock.OperationContext, this, false, true));
            OperationName = AddProperty(new DomainProperty<string, SysOperationLock, SysOperationLockDomainObject>("OperationName", DomainObjectPropertyKeys.SysOperationLock.OperationName, this, false, true));
            ProcessId = AddProperty(new DomainProperty<int?, SysOperationLock, SysOperationLockDomainObject>("ProcessId", DomainObjectPropertyKeys.SysOperationLock.ProcessId, this, false, true));
            UserId = AddProperty(new DomainProperty<int, SysOperationLock, SysOperationLockDomainObject>("UserId", DomainObjectPropertyKeys.SysOperationLock.UserId, this, false, true));
        }

        
        public DomainProperty<DateTime, SysOperationLock, SysOperationLockDomainObject> AquiredTime { get; private set; }

        public DomainProperty<DateTime, SysOperationLock, SysOperationLockDomainObject> ExpirationTime { get; private set; }

        public DomainProperty<string, SysOperationLock, SysOperationLockDomainObject> MachineName { get; private set; }

        public DomainProperty<string, SysOperationLock, SysOperationLockDomainObject> OperationContext { get; private set; }

        public DomainProperty<string, SysOperationLock, SysOperationLockDomainObject> OperationName { get; private set; }

        public DomainProperty<int?, SysOperationLock, SysOperationLockDomainObject> ProcessId { get; private set; }

        public DomainProperty<int, SysOperationLock, SysOperationLockDomainObject> UserId { get; private set; }
    }
    #endregion
    #region SysOperationResult

    public sealed class SysOperationResultDomainObject : DomainObject<SysOperationResult, SysOperationResultDomainObject>
    {
        public SysOperationResultDomainObject()
            : base("SysOperationResult", DomainObjectKeys.SysOperationResult, 2, true)
        {
            Id = AddProperty(new DomainProperty<byte, SysOperationResult, SysOperationResultDomainObject>("Id", DomainObjectPropertyKeys.SysOperationResult.Id, this, false, true));
            Name = AddProperty(new DomainProperty<string, SysOperationResult, SysOperationResultDomainObject>("Name", DomainObjectPropertyKeys.SysOperationResult.Name, this, false, true));
        }

        
        public DomainProperty<byte, SysOperationResult, SysOperationResultDomainObject> Id { get; private set; }

        public DomainProperty<string, SysOperationResult, SysOperationResultDomainObject> Name { get; private set; }
    }
    #endregion
    #region SysPermission

    public sealed class SysPermissionDomainObject : DomainObject<SysPermission, SysPermissionDomainObject>
    {
        public SysPermissionDomainObject()
            : base("SysPermission", DomainObjectKeys.SysPermission, 7, true)
        {
            CodeName = AddProperty(new DomainProperty<string, SysPermission, SysPermissionDomainObject>("CodeName", DomainObjectPropertyKeys.SysPermission.CodeName, this, false, true));
            Description = AddProperty(new DomainProperty<string, SysPermission, SysPermissionDomainObject>("Description", DomainObjectPropertyKeys.SysPermission.Description, this, false, true));
            DisplayName = AddProperty(new DomainProperty<string, SysPermission, SysPermissionDomainObject>("DisplayName", DomainObjectPropertyKeys.SysPermission.DisplayName, this, false, true));
            Guid = AddProperty(new DomainProperty<Guid, SysPermission, SysPermissionDomainObject>("Guid", DomainObjectPropertyKeys.SysPermission.Guid, this, false, true));
            Id = AddProperty(new DomainProperty<int, SysPermission, SysPermissionDomainObject>("Id", DomainObjectPropertyKeys.SysPermission.Id, this, false, true));
            ObjectId = AddProperty(new DomainProperty<int, SysPermission, SysPermissionDomainObject>("ObjectId", DomainObjectPropertyKeys.SysPermission.ObjectId, this, false, true));
            Type = AddProperty(new DomainProperty<byte, SysPermission, SysPermissionDomainObject>("Type", DomainObjectPropertyKeys.SysPermission.Type, this, false, true));
        }

        
        public DomainProperty<string, SysPermission, SysPermissionDomainObject> CodeName { get; private set; }

        public DomainProperty<string, SysPermission, SysPermissionDomainObject> Description { get; private set; }

        public DomainProperty<string, SysPermission, SysPermissionDomainObject> DisplayName { get; private set; }

        public DomainProperty<Guid, SysPermission, SysPermissionDomainObject> Guid { get; private set; }

        public DomainProperty<int, SysPermission, SysPermissionDomainObject> Id { get; private set; }

        public DomainProperty<int, SysPermission, SysPermissionDomainObject> ObjectId { get; private set; }

        public DomainProperty<byte, SysPermission, SysPermissionDomainObject> Type { get; private set; }
    }
    #endregion
    #region SysPermissionType

    public sealed class SysPermissionTypeDomainObject : DomainObject<SysPermissionType, SysPermissionTypeDomainObject>
    {
        public SysPermissionTypeDomainObject()
            : base("SysPermissionType", DomainObjectKeys.SysPermissionType, 4, true)
        {
            CodeName = AddProperty(new DomainProperty<string, SysPermissionType, SysPermissionTypeDomainObject>("CodeName", DomainObjectPropertyKeys.SysPermissionType.CodeName, this, false, true));
            Description = AddProperty(new DomainProperty<string, SysPermissionType, SysPermissionTypeDomainObject>("Description", DomainObjectPropertyKeys.SysPermissionType.Description, this, false, true));
            DisplayName = AddProperty(new DomainProperty<string, SysPermissionType, SysPermissionTypeDomainObject>("DisplayName", DomainObjectPropertyKeys.SysPermissionType.DisplayName, this, false, true));
            Id = AddProperty(new DomainProperty<byte, SysPermissionType, SysPermissionTypeDomainObject>("Id", DomainObjectPropertyKeys.SysPermissionType.Id, this, false, true));
        }

        
        public DomainProperty<string, SysPermissionType, SysPermissionTypeDomainObject> CodeName { get; private set; }

        public DomainProperty<string, SysPermissionType, SysPermissionTypeDomainObject> Description { get; private set; }

        public DomainProperty<string, SysPermissionType, SysPermissionTypeDomainObject> DisplayName { get; private set; }

        public DomainProperty<byte, SysPermissionType, SysPermissionTypeDomainObject> Id { get; private set; }
    }
    #endregion
    #region SysRefreshToken

    public sealed class SysRefreshTokenDomainObject : DomainObject<SysRefreshToken, SysRefreshTokenDomainObject>
    {
        public SysRefreshTokenDomainObject()
            : base("SysRefreshToken", DomainObjectKeys.SysRefreshToken, 4, true)
        {
            ClientId = AddProperty(new DomainProperty<string, SysRefreshToken, SysRefreshTokenDomainObject>("ClientId", DomainObjectPropertyKeys.SysRefreshToken.ClientId, this, false, true));
            ExpiresUtc = AddProperty(new DomainProperty<DateTimeOffset, SysRefreshToken, SysRefreshTokenDomainObject>("ExpiresUtc", DomainObjectPropertyKeys.SysRefreshToken.ExpiresUtc, this, false, true));
            Token = AddProperty(new DomainProperty<string, SysRefreshToken, SysRefreshTokenDomainObject>("Token", DomainObjectPropertyKeys.SysRefreshToken.Token, this, false, true));
            UserId = AddProperty(new DomainProperty<int, SysRefreshToken, SysRefreshTokenDomainObject>("UserId", DomainObjectPropertyKeys.SysRefreshToken.UserId, this, false, true));
        }

        
        public DomainProperty<string, SysRefreshToken, SysRefreshTokenDomainObject> ClientId { get; private set; }

        public DomainProperty<DateTimeOffset, SysRefreshToken, SysRefreshTokenDomainObject> ExpiresUtc { get; private set; }

        public DomainProperty<string, SysRefreshToken, SysRefreshTokenDomainObject> Token { get; private set; }

        public DomainProperty<int, SysRefreshToken, SysRefreshTokenDomainObject> UserId { get; private set; }
    }
    #endregion
    #region SysResetPasswordToken

    public sealed class SysResetPasswordTokenDomainObject : DomainObject<SysResetPasswordToken, SysResetPasswordTokenDomainObject>
    {
        public SysResetPasswordTokenDomainObject()
            : base("SysResetPasswordToken", DomainObjectKeys.SysResetPasswordToken, 5, true)
        {
            Id = AddProperty(new DomainProperty<int, SysResetPasswordToken, SysResetPasswordTokenDomainObject>("Id", DomainObjectPropertyKeys.SysResetPasswordToken.Id, this, false, true));
            IsExecuted = AddProperty(new DomainProperty<bool, SysResetPasswordToken, SysResetPasswordTokenDomainObject>("IsExecuted", DomainObjectPropertyKeys.SysResetPasswordToken.IsExecuted, this, false, true));
            Token = AddProperty(new DomainProperty<string, SysResetPasswordToken, SysResetPasswordTokenDomainObject>("Token", DomainObjectPropertyKeys.SysResetPasswordToken.Token, this, false, true));
            UserId = AddProperty(new DomainProperty<int, SysResetPasswordToken, SysResetPasswordTokenDomainObject>("UserId", DomainObjectPropertyKeys.SysResetPasswordToken.UserId, this, false, true));
            ValidFrom = AddProperty(new DomainProperty<DateTimeOffset, SysResetPasswordToken, SysResetPasswordTokenDomainObject>("ValidFrom", DomainObjectPropertyKeys.SysResetPasswordToken.ValidFrom, this, false, true));
        }

        
        public DomainProperty<int, SysResetPasswordToken, SysResetPasswordTokenDomainObject> Id { get; private set; }

        public DomainProperty<bool, SysResetPasswordToken, SysResetPasswordTokenDomainObject> IsExecuted { get; private set; }

        public DomainProperty<string, SysResetPasswordToken, SysResetPasswordTokenDomainObject> Token { get; private set; }

        public DomainProperty<int, SysResetPasswordToken, SysResetPasswordTokenDomainObject> UserId { get; private set; }

        public DomainProperty<DateTimeOffset, SysResetPasswordToken, SysResetPasswordTokenDomainObject> ValidFrom { get; private set; }
    }
    #endregion
    #region SysRole

    public sealed class SysRoleDomainObject : DomainObject<SysRole, SysRoleDomainObject>
    {
        public SysRoleDomainObject()
            : base("SysRole", DomainObjectKeys.SysRole, 6, true)
        {
            Description = AddProperty(new DomainProperty<string, SysRole, SysRoleDomainObject>("Description", DomainObjectPropertyKeys.SysRole.Description, this, false, true));
            Id = AddProperty(new DomainProperty<int, SysRole, SysRoleDomainObject>("Id", DomainObjectPropertyKeys.SysRole.Id, this, false, true));
            IsOwnByUser = AddProperty(new DomainProperty<bool, SysRole, SysRoleDomainObject>("IsOwnByUser", DomainObjectPropertyKeys.SysRole.IsOwnByUser, this, false, true));
            IsSystem = AddProperty(new DomainProperty<bool, SysRole, SysRoleDomainObject>("IsSystem", DomainObjectPropertyKeys.SysRole.IsSystem, this, false, true));
            Name = AddProperty(new DomainProperty<string, SysRole, SysRoleDomainObject>("Name", DomainObjectPropertyKeys.SysRole.Name, this, false, true));
            OwnerUserID = AddProperty(new DomainProperty<int?, SysRole, SysRoleDomainObject>("OwnerUserID", DomainObjectPropertyKeys.SysRole.OwnerUserID, this, false, true));
        }

        
        public DomainProperty<string, SysRole, SysRoleDomainObject> Description { get; private set; }

        public DomainProperty<int, SysRole, SysRoleDomainObject> Id { get; private set; }

        public DomainProperty<bool, SysRole, SysRoleDomainObject> IsOwnByUser { get; private set; }

        public DomainProperty<bool, SysRole, SysRoleDomainObject> IsSystem { get; private set; }

        public DomainProperty<string, SysRole, SysRoleDomainObject> Name { get; private set; }

        public DomainProperty<int?, SysRole, SysRoleDomainObject> OwnerUserID { get; private set; }
    }
    #endregion
    #region SysRolePermission

    public sealed class SysRolePermissionDomainObject : DomainObject<SysRolePermission, SysRolePermissionDomainObject>
    {
        public SysRolePermissionDomainObject()
            : base("SysRolePermission", DomainObjectKeys.SysRolePermission, 3, true)
        {
            Id = AddProperty(new DomainProperty<int, SysRolePermission, SysRolePermissionDomainObject>("Id", DomainObjectPropertyKeys.SysRolePermission.Id, this, false, true));
            PermissionId = AddProperty(new DomainProperty<int, SysRolePermission, SysRolePermissionDomainObject>("PermissionId", DomainObjectPropertyKeys.SysRolePermission.PermissionId, this, false, true));
            RoleId = AddProperty(new DomainProperty<int, SysRolePermission, SysRolePermissionDomainObject>("RoleId", DomainObjectPropertyKeys.SysRolePermission.RoleId, this, false, true));
        }

        
        public DomainProperty<int, SysRolePermission, SysRolePermissionDomainObject> Id { get; private set; }

        public DomainProperty<int, SysRolePermission, SysRolePermissionDomainObject> PermissionId { get; private set; }

        public DomainProperty<int, SysRolePermission, SysRolePermissionDomainObject> RoleId { get; private set; }
    }
    #endregion
    #region SysSetting

    public sealed class SysSettingDomainObject : DomainObject<SysSetting, SysSettingDomainObject>
    {
        public SysSettingDomainObject()
            : base("SysSetting", DomainObjectKeys.SysSetting, 4, true)
        {
            Id = AddProperty(new DomainProperty<int, SysSetting, SysSettingDomainObject>("Id", DomainObjectPropertyKeys.SysSetting.Id, this, false, true));
            SettingPropertyId = AddProperty(new DomainProperty<int, SysSetting, SysSettingDomainObject>("SettingPropertyId", DomainObjectPropertyKeys.SysSetting.SettingPropertyId, this, false, true));
            StringValue = AddProperty(new DomainProperty<string, SysSetting, SysSettingDomainObject>("StringValue", DomainObjectPropertyKeys.SysSetting.StringValue, this, false, true));
            UserId = AddProperty(new DomainProperty<int?, SysSetting, SysSettingDomainObject>("UserId", DomainObjectPropertyKeys.SysSetting.UserId, this, false, true));
        }

        
        public DomainProperty<int, SysSetting, SysSettingDomainObject> Id { get; private set; }

        public DomainProperty<int, SysSetting, SysSettingDomainObject> SettingPropertyId { get; private set; }

        public DomainProperty<string, SysSetting, SysSettingDomainObject> StringValue { get; private set; }

        public DomainProperty<int?, SysSetting, SysSettingDomainObject> UserId { get; private set; }
    }
    #endregion
    #region SysSettingProperty

    public sealed class SysSettingPropertyDomainObject : DomainObject<SysSettingProperty, SysSettingPropertyDomainObject>
    {
        public SysSettingPropertyDomainObject()
            : base("SysSettingProperty", DomainObjectKeys.SysSettingProperty, 8, true)
        {
            DefaultType = AddProperty(new DomainProperty<string, SysSettingProperty, SysSettingPropertyDomainObject>("DefaultType", DomainObjectPropertyKeys.SysSettingProperty.DefaultType, this, false, true));
            Description = AddProperty(new DomainProperty<string, SysSettingProperty, SysSettingPropertyDomainObject>("Description", DomainObjectPropertyKeys.SysSettingProperty.Description, this, false, true));
            GroupName = AddProperty(new DomainProperty<string, SysSettingProperty, SysSettingPropertyDomainObject>("GroupName", DomainObjectPropertyKeys.SysSettingProperty.GroupName, this, false, true));
            Id = AddProperty(new DomainProperty<int, SysSettingProperty, SysSettingPropertyDomainObject>("Id", DomainObjectPropertyKeys.SysSettingProperty.Id, this, false, true));
            IsManaged = AddProperty(new DomainProperty<bool, SysSettingProperty, SysSettingPropertyDomainObject>("IsManaged", DomainObjectPropertyKeys.SysSettingProperty.IsManaged, this, false, true));
            IsOverridable = AddProperty(new DomainProperty<bool, SysSettingProperty, SysSettingPropertyDomainObject>("IsOverridable", DomainObjectPropertyKeys.SysSettingProperty.IsOverridable, this, false, true));
            Name = AddProperty(new DomainProperty<string, SysSettingProperty, SysSettingPropertyDomainObject>("Name", DomainObjectPropertyKeys.SysSettingProperty.Name, this, false, true));
            UIEditorType = AddProperty(new DomainProperty<string, SysSettingProperty, SysSettingPropertyDomainObject>("UIEditorType", DomainObjectPropertyKeys.SysSettingProperty.UIEditorType, this, false, true));
        }

        
        public DomainProperty<string, SysSettingProperty, SysSettingPropertyDomainObject> DefaultType { get; private set; }

        public DomainProperty<string, SysSettingProperty, SysSettingPropertyDomainObject> Description { get; private set; }

        public DomainProperty<string, SysSettingProperty, SysSettingPropertyDomainObject> GroupName { get; private set; }

        public DomainProperty<int, SysSettingProperty, SysSettingPropertyDomainObject> Id { get; private set; }

        public DomainProperty<bool, SysSettingProperty, SysSettingPropertyDomainObject> IsManaged { get; private set; }

        public DomainProperty<bool, SysSettingProperty, SysSettingPropertyDomainObject> IsOverridable { get; private set; }

        public DomainProperty<string, SysSettingProperty, SysSettingPropertyDomainObject> Name { get; private set; }

        public DomainProperty<string, SysSettingProperty, SysSettingPropertyDomainObject> UIEditorType { get; private set; }
    }
    #endregion
    #region SysUser

    public sealed class SysUserDomainObject : DomainObject<SysUser, SysUserDomainObject>
    {
        public SysUserDomainObject()
            : base("SysUser", DomainObjectKeys.SysUser, 14, true)
        {
            AccountName = AddProperty(new DomainProperty<string, SysUser, SysUserDomainObject>("AccountName", DomainObjectPropertyKeys.SysUser.AccountName, this, false, true));
            CreateDate = AddProperty(new DomainProperty<DateTime, SysUser, SysUserDomainObject>("CreateDate", DomainObjectPropertyKeys.SysUser.CreateDate, this, false, false));
            DeactivationDate = AddProperty(new DomainProperty<DateTime?, SysUser, SysUserDomainObject>("DeactivationDate", DomainObjectPropertyKeys.SysUser.DeactivationDate, this, false, true));
            Description = AddProperty(new DomainProperty<string, SysUser, SysUserDomainObject>("Description", DomainObjectPropertyKeys.SysUser.Description, this, false, true));
            DisplayName = AddProperty(new DomainProperty<string, SysUser, SysUserDomainObject>("DisplayName", DomainObjectPropertyKeys.SysUser.DisplayName, this, false, true));
            EMail = AddProperty(new DomainProperty<string, SysUser, SysUserDomainObject>("EMail", DomainObjectPropertyKeys.SysUser.EMail, this, false, true));
            EmailToken = AddProperty(new DomainProperty<string, SysUser, SysUserDomainObject>("EmailToken", DomainObjectPropertyKeys.SysUser.EmailToken, this, false, true));
            FullAccess = AddProperty(new DomainProperty<bool, SysUser, SysUserDomainObject>("FullAccess", DomainObjectPropertyKeys.SysUser.FullAccess, this, false, true));
            Id = AddProperty(new DomainProperty<int, SysUser, SysUserDomainObject>("Id", DomainObjectPropertyKeys.SysUser.Id, this, false, true));
            IsAnonymous = AddProperty(new DomainProperty<bool, SysUser, SysUserDomainObject>("IsAnonymous", DomainObjectPropertyKeys.SysUser.IsAnonymous, this, false, true));
            IsDeactivated = AddProperty(new DomainProperty<bool, SysUser, SysUserDomainObject>("IsDeactivated", DomainObjectPropertyKeys.SysUser.IsDeactivated, this, false, true));
            IsEmailConfirmed = AddProperty(new DomainProperty<bool, SysUser, SysUserDomainObject>("IsEmailConfirmed", DomainObjectPropertyKeys.SysUser.IsEmailConfirmed, this, false, true));
            IsSystemUser = AddProperty(new DomainProperty<bool, SysUser, SysUserDomainObject>("IsSystemUser", DomainObjectPropertyKeys.SysUser.IsSystemUser, this, false, true));
            PasswordHash = AddProperty(new DomainProperty<byte[], SysUser, SysUserDomainObject>("PasswordHash", DomainObjectPropertyKeys.SysUser.PasswordHash, this, false, true));
        }

        
        public DomainProperty<string, SysUser, SysUserDomainObject> AccountName { get; private set; }

        public DomainProperty<DateTime, SysUser, SysUserDomainObject> CreateDate { get; private set; }

        public DomainProperty<DateTime?, SysUser, SysUserDomainObject> DeactivationDate { get; private set; }

        public DomainProperty<string, SysUser, SysUserDomainObject> Description { get; private set; }

        public DomainProperty<string, SysUser, SysUserDomainObject> DisplayName { get; private set; }

        public DomainProperty<string, SysUser, SysUserDomainObject> EMail { get; private set; }

        public DomainProperty<string, SysUser, SysUserDomainObject> EmailToken { get; private set; }

        public DomainProperty<bool, SysUser, SysUserDomainObject> FullAccess { get; private set; }

        public DomainProperty<int, SysUser, SysUserDomainObject> Id { get; private set; }

        public DomainProperty<bool, SysUser, SysUserDomainObject> IsAnonymous { get; private set; }

        public DomainProperty<bool, SysUser, SysUserDomainObject> IsDeactivated { get; private set; }

        public DomainProperty<bool, SysUser, SysUserDomainObject> IsEmailConfirmed { get; private set; }

        public DomainProperty<bool, SysUser, SysUserDomainObject> IsSystemUser { get; private set; }

        public DomainProperty<byte[], SysUser, SysUserDomainObject> PasswordHash { get; private set; }
    }
    #endregion
    #region SysUserPermissionsDisplayView

    public sealed class SysUserPermissionsDisplayViewDomainObject : DomainObject<SysUserPermissionsDisplayView, SysUserPermissionsDisplayViewDomainObject>
    {
        public SysUserPermissionsDisplayViewDomainObject()
            : base("SysUserPermissionsDisplayView", DomainObjectKeys.SysUserPermissionsDisplayView, 4, true)
        {
            PermissionId = AddProperty(new DomainProperty<int, SysUserPermissionsDisplayView, SysUserPermissionsDisplayViewDomainObject>("PermissionId", DomainObjectPropertyKeys.SysUserPermissionsDisplayView.PermissionId, this, false, true));
            PermissionName = AddProperty(new DomainProperty<string, SysUserPermissionsDisplayView, SysUserPermissionsDisplayViewDomainObject>("PermissionName", DomainObjectPropertyKeys.SysUserPermissionsDisplayView.PermissionName, this, false, true));
            Roles = AddProperty(new DomainProperty<string, SysUserPermissionsDisplayView, SysUserPermissionsDisplayViewDomainObject>("Roles", DomainObjectPropertyKeys.SysUserPermissionsDisplayView.Roles, this, false, true));
            UserId = AddProperty(new DomainProperty<int, SysUserPermissionsDisplayView, SysUserPermissionsDisplayViewDomainObject>("UserId", DomainObjectPropertyKeys.SysUserPermissionsDisplayView.UserId, this, false, true));
        }

        
        public DomainProperty<int, SysUserPermissionsDisplayView, SysUserPermissionsDisplayViewDomainObject> PermissionId { get; private set; }

        public DomainProperty<string, SysUserPermissionsDisplayView, SysUserPermissionsDisplayViewDomainObject> PermissionName { get; private set; }

        public DomainProperty<string, SysUserPermissionsDisplayView, SysUserPermissionsDisplayViewDomainObject> Roles { get; private set; }

        public DomainProperty<int, SysUserPermissionsDisplayView, SysUserPermissionsDisplayViewDomainObject> UserId { get; private set; }
    }
    #endregion
    #region SysUserRole

    public sealed class SysUserRoleDomainObject : DomainObject<SysUserRole, SysUserRoleDomainObject>
    {
        public SysUserRoleDomainObject()
            : base("SysUserRole", DomainObjectKeys.SysUserRole, 3, true)
        {
            Id = AddProperty(new DomainProperty<int, SysUserRole, SysUserRoleDomainObject>("Id", DomainObjectPropertyKeys.SysUserRole.Id, this, false, true));
            RoleId = AddProperty(new DomainProperty<int, SysUserRole, SysUserRoleDomainObject>("RoleId", DomainObjectPropertyKeys.SysUserRole.RoleId, this, false, true));
            UserId = AddProperty(new DomainProperty<int, SysUserRole, SysUserRoleDomainObject>("UserId", DomainObjectPropertyKeys.SysUserRole.UserId, this, false, true));
        }

        
        public DomainProperty<int, SysUserRole, SysUserRoleDomainObject> Id { get; private set; }

        public DomainProperty<int, SysUserRole, SysUserRoleDomainObject> RoleId { get; private set; }

        public DomainProperty<int, SysUserRole, SysUserRoleDomainObject> UserId { get; private set; }
    }
    #endregion
    #region SysUsersDisplayView

    public sealed class SysUsersDisplayViewDomainObject : DomainObject<SysUsersDisplayView, SysUsersDisplayViewDomainObject>
    {
        public SysUsersDisplayViewDomainObject()
            : base("SysUsersDisplayView", DomainObjectKeys.SysUsersDisplayView, 2, true)
        {
            Id = AddProperty(new DomainProperty<int, SysUsersDisplayView, SysUsersDisplayViewDomainObject>("Id", DomainObjectPropertyKeys.SysUsersDisplayView.Id, this, false, true));
            UserRoleId = AddProperty(new DomainProperty<int?, SysUsersDisplayView, SysUsersDisplayViewDomainObject>("UserRoleId", DomainObjectPropertyKeys.SysUsersDisplayView.UserRoleId, this, false, true));
        }

        
        public DomainProperty<int, SysUsersDisplayView, SysUsersDisplayViewDomainObject> Id { get; private set; }

        public DomainProperty<int?, SysUsersDisplayView, SysUsersDisplayViewDomainObject> UserRoleId { get; private set; }
    }
    #endregion
}
