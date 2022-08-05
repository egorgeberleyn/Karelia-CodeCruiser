using BusinessFramework.Contracts.Metadata;


namespace Karelia.WebAPI.Contracts
{
    /// <summary>
    ///     Domain actions' keys
    /// </summary>
    public abstract partial class DomainActions
    {
        public static class Object
        {
            public static class CarWorkType
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.CarWorkType_Create, @"Add New 'Car work type'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.CarWorkType_Update, @"Edit 'Car work type'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.CarWorkType_Delete, @"Delete 'Car work type'", false);
            }

            public static class Office
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.Office_Create, @"Add New 'Office'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.Office_Update, @"Edit 'Office'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.Office_Delete, @"Delete 'Office'", false);
            }

            public static class CarArrivalReasonType
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.CarArrivalReasonType_Create, @"Add New 'Car arrival reason type'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.CarArrivalReasonType_Update, @"Edit 'Car arrival reason type'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.CarArrivalReasonType_Delete, @"Delete 'Car arrival reason type'", false);
            }

            public static class SysResetPasswordToken
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.SysResetPasswordToken_Create, @"Add New 'Reset password token'", true);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.SysResetPasswordToken_Update, @"Edit 'Reset password token'", true);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.SysResetPasswordToken_Delete, @"Delete 'Reset password token'", true);
            }

            public static class SysRole
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.SysRole_Create, @"Add New 'Role'", true);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.SysRole_Update, @"Edit 'Role'", true);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.SysRole_Delete, @"Delete 'Role'", true);
            }

            public static class CarServiceWork
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.CarServiceWork_Create, @"Add New 'Car service work'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.CarServiceWork_Update, @"Edit 'Car service work'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.CarServiceWork_Delete, @"Delete 'Car service work'", false);
            }

            public static class Car
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.Car_Create, @"Add New 'Car'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.Car_Update, @"Edit 'Car'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.Car_Delete, @"Delete 'Car'", false);
            }

            public static class SubTask
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.SubTask_Create, @"Add New 'Sub task'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.SubTask_Update, @"Edit 'Sub task'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.SubTask_Delete, @"Delete 'Sub task'", false);
            }

            public static class CarModelPart
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.CarModelPart_Create, @"Add New 'Car model part'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.CarModelPart_Update, @"Edit 'Car model part'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.CarModelPart_Delete, @"Delete 'Car model part'", false);
            }

            public static class SysOperationLock
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.SysOperationLock_Create, @"Add New 'Operation lock'", true);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.SysOperationLock_Update, @"Edit 'Operation lock'", true);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.SysOperationLock_Delete, @"Delete 'Operation lock'", true);
            }

            public static class CarService
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.CarService_Create, @"Add New 'Car service'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.CarService_Update, @"Edit 'Car service'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.CarService_Delete, @"Delete 'Car service'", false);
            }

            public static class OfiiceEmployee
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.OfiiceEmployee_Create, @"Add New 'OfficeEmployee'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.OfiiceEmployee_Update, @"Edit 'OfficeEmployee'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.OfiiceEmployee_Delete, @"Delete 'OfficeEmployee'", false);
            }

            public static class SysSetting
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.SysSetting_Create, @"Add New 'Setting'", true);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.SysSetting_Update, @"Edit 'Setting'", true);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.SysSetting_Delete, @"Delete 'Setting'", true);
            }

            public static class MainTask
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.MainTask_Create, @"Add New 'Main task'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.MainTask_Update, @"Edit 'Main task'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.MainTask_Delete, @"Delete 'Main task'", false);
            }

            public static class OfficeEquipment
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.OfficeEquipment_Create, @"Add New 'Office equipment'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.OfficeEquipment_Update, @"Edit 'Office equipment'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.OfficeEquipment_Delete, @"Delete 'Office equipment'", false);
            }

            public static class CarServicePart
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.CarServicePart_Create, @"Add New 'Car service part'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.CarServicePart_Update, @"Edit 'Car service part'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.CarServicePart_Delete, @"Delete 'Car service part'", false);
            }

            public static class MethodicalToolkit
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.MethodicalToolkit_Create, @"Add New 'Methodical toolkit'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.MethodicalToolkit_Update, @"Edit 'Methodical toolkit'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.MethodicalToolkit_Delete, @"Delete 'Methodical toolkit'", false);
            }

            public static class SysSettingProperty
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.SysSettingProperty_Create, @"Add New 'Setting property'", true);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.SysSettingProperty_Update, @"Edit 'Setting property'", true);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.SysSettingProperty_Delete, @"Delete 'Setting property'", true);
            }

            public static class CarModel
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.CarModel_Create, @"Add New 'Car model'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.CarModel_Update, @"Edit 'Car model'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.CarModel_Delete, @"Delete 'Car model'", false);
            }

            public static class MethodicalToolkitFile
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.MethodicalToolkitFile_Create, @"Add New 'Methodical toolkit file'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.MethodicalToolkitFile_Update, @"Edit 'Methodical toolkit file'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.MethodicalToolkitFile_Delete, @"Delete 'Methodical toolkit file'", false);
            }

            public static class OfficeEquipmentModel
            {
                public static readonly ObjectDomainAction Create = new ObjectDomainAction("Create", DomainActionKeys.Object.OfficeEquipmentModel_Create, @"Add New 'Office equipment model'", false);
                public static readonly ObjectDomainAction Update = new ObjectDomainAction("Update", DomainActionKeys.Object.OfficeEquipmentModel_Update, @"Edit 'Office equipment model'", false);
                public static readonly ObjectDomainAction Delete = new ObjectDomainAction("Delete", DomainActionKeys.Object.OfficeEquipmentModel_Delete, @"Delete 'Office equipment model'", false);
            }

        }
    }
}