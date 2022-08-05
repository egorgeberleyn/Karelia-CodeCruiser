using BusinessFramework;


namespace Karelia.WebAPI.Contracts
{
    /// <summary>
    /// Domain permissions
    /// </summary>
    public enum DomainPermissions
    {
        /// <summary>
        /// System SettingManagement. Allows editing of global settings or other users settings
        /// </summary>
        SettingManagement = Constants.Permissions.SettingManagement,

        /// <summary>
        /// System ReportManagement. Allows editing reports
        /// </summary>
        ReportManagement = Constants.Permissions.ReportManagement,

        /// <summary>
        /// Global NewGlobalPermission1. 
        /// </summary>
        NewGlobalPermission1 = 0x10,

        /// <summary>
        /// Global Operation lock management. Allows to set lock for operation
        /// </summary>
        OperationLock = 0x20,

        /// <summary>
        /// Global Settings. Allow read and edit user settings
        /// </summary>
        Settings = 0x40,

        /// <summary>
        /// Read Car work type.Read. 
        /// </summary>
        CarWorkType_Read = 0x80,

        /// <summary>
        /// Create Car work type.Create. 
        /// </summary>
        CarWorkType_Create = 0x101,

        /// <summary>
        /// Update Car work type.Update. 
        /// </summary>
        CarWorkType_Update = 0x102,

        /// <summary>
        /// Delete Car work type.Delete. 
        /// </summary>
        CarWorkType_Delete = 0x104,

        /// <summary>
        /// Read Office.Read. 
        /// </summary>
        Office_Read = 0x108,

        /// <summary>
        /// Create Office.Create. 
        /// </summary>
        Office_Create = 0x110,

        /// <summary>
        /// Update Office.Update. 
        /// </summary>
        Office_Update = 0x120,

        /// <summary>
        /// Delete Office.Delete. 
        /// </summary>
        Office_Delete = 0x140,

        /// <summary>
        /// Read Car arrival reason type.Read. 
        /// </summary>
        CarArrivalReasonType_Read = 0x180,

        /// <summary>
        /// Create Car arrival reason type.Create. 
        /// </summary>
        CarArrivalReasonType_Create = 0x201,

        /// <summary>
        /// Update Car arrival reason type.Update. 
        /// </summary>
        CarArrivalReasonType_Update = 0x202,

        /// <summary>
        /// Delete Car arrival reason type.Delete. 
        /// </summary>
        CarArrivalReasonType_Delete = 0x204,

        /// <summary>
        /// Read Reset password token.Read. 
        /// </summary>
        SysResetPasswordToken_Read = 0x208,

        /// <summary>
        /// Create Reset password token.Create. 
        /// </summary>
        SysResetPasswordToken_Create = 0x210,

        /// <summary>
        /// Update Reset password token.Update. 
        /// </summary>
        SysResetPasswordToken_Update = 0x220,

        /// <summary>
        /// Delete Reset password token.Delete. 
        /// </summary>
        SysResetPasswordToken_Delete = 0x240,

        /// <summary>
        /// Read Role.Read. 
        /// </summary>
        SysRole_Read = 0x280,

        /// <summary>
        /// Create Role.Create. 
        /// </summary>
        SysRole_Create = 0x301,

        /// <summary>
        /// Update Role.Update. 
        /// </summary>
        SysRole_Update = 0x302,

        /// <summary>
        /// Delete Role.Delete. 
        /// </summary>
        SysRole_Delete = 0x304,

        /// <summary>
        /// Read Car service work.Read. 
        /// </summary>
        CarServiceWork_Read = 0x308,

        /// <summary>
        /// Create Car service work.Create. 
        /// </summary>
        CarServiceWork_Create = 0x310,

        /// <summary>
        /// Update Car service work.Update. 
        /// </summary>
        CarServiceWork_Update = 0x320,

        /// <summary>
        /// Delete Car service work.Delete. 
        /// </summary>
        CarServiceWork_Delete = 0x340,

        /// <summary>
        /// Read Car.Read. 
        /// </summary>
        Car_Read = 0x380,

        /// <summary>
        /// Create Car.Create. 
        /// </summary>
        Car_Create = 0x401,

        /// <summary>
        /// Update Car.Update. 
        /// </summary>
        Car_Update = 0x402,

        /// <summary>
        /// Delete Car.Delete. 
        /// </summary>
        Car_Delete = 0x404,

        /// <summary>
        /// Read Sub task.Read. 
        /// </summary>
        SubTask_Read = 0x408,

        /// <summary>
        /// Create Sub task.Create. 
        /// </summary>
        SubTask_Create = 0x410,

        /// <summary>
        /// Update Sub task.Update. 
        /// </summary>
        SubTask_Update = 0x420,

        /// <summary>
        /// Delete Sub task.Delete. 
        /// </summary>
        SubTask_Delete = 0x440,

        /// <summary>
        /// Read Car model part.Read. 
        /// </summary>
        CarModelPart_Read = 0x480,

        /// <summary>
        /// Create Car model part.Create. 
        /// </summary>
        CarModelPart_Create = 0x501,

        /// <summary>
        /// Update Car model part.Update. 
        /// </summary>
        CarModelPart_Update = 0x502,

        /// <summary>
        /// Delete Car model part.Delete. 
        /// </summary>
        CarModelPart_Delete = 0x504,

        /// <summary>
        /// Read Car service.Read. 
        /// </summary>
        CarService_Read = 0x508,

        /// <summary>
        /// Create Car service.Create. 
        /// </summary>
        CarService_Create = 0x510,

        /// <summary>
        /// Update Car service.Update. 
        /// </summary>
        CarService_Update = 0x520,

        /// <summary>
        /// Delete Car service.Delete. 
        /// </summary>
        CarService_Delete = 0x540,

        /// <summary>
        /// Read OfficeEmployee.Read. 
        /// </summary>
        OfiiceEmployee_Read = 0x580,

        /// <summary>
        /// Create OfficeEmployee.Create. 
        /// </summary>
        OfiiceEmployee_Create = 0x601,

        /// <summary>
        /// Update OfficeEmployee.Update. 
        /// </summary>
        OfiiceEmployee_Update = 0x602,

        /// <summary>
        /// Delete OfficeEmployee.Delete. 
        /// </summary>
        OfiiceEmployee_Delete = 0x604,

        /// <summary>
        /// Read Main task.Read. 
        /// </summary>
        MainTask_Read = 0x608,

        /// <summary>
        /// Create Main task.Create. 
        /// </summary>
        MainTask_Create = 0x610,

        /// <summary>
        /// Update Main task.Update. 
        /// </summary>
        MainTask_Update = 0x620,

        /// <summary>
        /// Delete Main task.Delete. 
        /// </summary>
        MainTask_Delete = 0x640,

        /// <summary>
        /// Read Office equipment.Read. 
        /// </summary>
        OfficeEquipment_Read = 0x680,

        /// <summary>
        /// Create Office equipment.Create. 
        /// </summary>
        OfficeEquipment_Create = 0x701,

        /// <summary>
        /// Update Office equipment.Update. 
        /// </summary>
        OfficeEquipment_Update = 0x702,

        /// <summary>
        /// Delete Office equipment.Delete. 
        /// </summary>
        OfficeEquipment_Delete = 0x704,

        /// <summary>
        /// Read Car service part.Read. 
        /// </summary>
        CarServicePart_Read = 0x708,

        /// <summary>
        /// Create Car service part.Create. 
        /// </summary>
        CarServicePart_Create = 0x710,

        /// <summary>
        /// Update Car service part.Update. 
        /// </summary>
        CarServicePart_Update = 0x720,

        /// <summary>
        /// Delete Car service part.Delete. 
        /// </summary>
        CarServicePart_Delete = 0x740,

        /// <summary>
        /// Read Methodical toolkit.Read. 
        /// </summary>
        MethodicalToolkit_Read = 0x780,

        /// <summary>
        /// Create Methodical toolkit.Create. 
        /// </summary>
        MethodicalToolkit_Create = 0x801,

        /// <summary>
        /// Update Methodical toolkit.Update. 
        /// </summary>
        MethodicalToolkit_Update = 0x802,

        /// <summary>
        /// Delete Methodical toolkit.Delete. 
        /// </summary>
        MethodicalToolkit_Delete = 0x804,

        /// <summary>
        /// Read Car model.Read. 
        /// </summary>
        CarModel_Read = 0x808,

        /// <summary>
        /// Create Car model.Create. 
        /// </summary>
        CarModel_Create = 0x810,

        /// <summary>
        /// Update Car model.Update. 
        /// </summary>
        CarModel_Update = 0x820,

        /// <summary>
        /// Delete Car model.Delete. 
        /// </summary>
        CarModel_Delete = 0x840,

        /// <summary>
        /// Read Methodical toolkit file.Read. 
        /// </summary>
        MethodicalToolkitFile_Read = 0x880,

        /// <summary>
        /// Create Methodical toolkit file.Create. 
        /// </summary>
        MethodicalToolkitFile_Create = 0x901,

        /// <summary>
        /// Update Methodical toolkit file.Update. 
        /// </summary>
        MethodicalToolkitFile_Update = 0x902,

        /// <summary>
        /// Delete Methodical toolkit file.Delete. 
        /// </summary>
        MethodicalToolkitFile_Delete = 0x904,

        /// <summary>
        /// Read Office equipment model.Read. 
        /// </summary>
        OfficeEquipmentModel_Read = 0x908,

        /// <summary>
        /// Create Office equipment model.Create. 
        /// </summary>
        OfficeEquipmentModel_Create = 0x910,

        /// <summary>
        /// Update Office equipment model.Update. 
        /// </summary>
        OfficeEquipmentModel_Update = 0x920,

        /// <summary>
        /// Delete Office equipment model.Delete. 
        /// </summary>
        OfficeEquipmentModel_Delete = 0x940,

        /// <summary>
        /// Read Основные Задачи.Read. 
        /// </summary>
        MainTaskQuery_Read = 0x980,

        /// <summary>
        /// Read CarServicePartQuery.Read. 
        /// </summary>
        CarServicePartQuery_Read = 0xA01,

        /// <summary>
        /// Read CarServiceQuery.Read. 
        /// </summary>
        CarServiceQuery_Read = 0xA02,

        /// <summary>
        /// Read Подзадачи.Read. 
        /// </summary>
        SubTaskQuery_Read = 0xA04,

        /// <summary>
        /// Read CarServiceWorkQuery.Read. 
        /// </summary>
        CarServiceWorkQuery_Read = 0xA08,

        /// <summary>
        /// Read OfficeEquipmentQuery.Read. 
        /// </summary>
        OfficeEquipmentQuery_Read = 0xA10,

        /// <summary>
        /// Read Автомобили.Read. 
        /// </summary>
        CarQuery_Read = 0xA20,

        
    }
}