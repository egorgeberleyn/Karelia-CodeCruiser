namespace Karelia.WebAPI.Contracts
{
    /// <summary>
    ///     Domain objects' keys
    /// </summary>
    public abstract class DomainObjectKeys
    {
         public const int SysUserPermissionsDisplayView = 1;
         public const int SysOperation = 6;
         public const int CarWorkType = 18;
         public const int SysObject = 24;
         public const int SysOperationResult = 35;
         public const int Office = 38;
         public const int CarArrivalReasonType = 44;
         public const int SysResetPasswordToken = 50;
         public const int SysRefreshToken = 60;
         public const int SysRole = 66;
         public const int SysUser = 78;
         public const int CarServiceWork = 94;
         public const int SysRolePermission = 104;
         public const int Car = 110;
         public const int SubTask = 119;
         public const int CarModelPart = 129;
         public const int SysOperationLock = 138;
         public const int SysUserRole = 150;
         public const int CarService = 156;
         public const int OfiiceEmployee = 170;
         public const int SysPermission = 178;
         public const int SysSetting = 188;
         public const int MainTask = 198;
         public const int OfficeEquipment = 210;
         public const int SysInfo = 225;
         public const int CarServicePart = 229;
         public const int SysObjectType = 239;
         public const int MethodicalToolkit = 242;
         public const int SysObjectClass = 248;
         public const int SysPermissionType = 253;
         public const int SysSettingProperty = 258;
         public const int SysUsersDisplayView = 270;
         public const int CarModel = 274;
         public const int MethodicalToolkitFile = 281;
         public const int OfficeEquipmentModel = 290;
         public const int MainTaskQuery = 296;
         public const int CarServicePartQuery = 305;
         public const int CarServiceQuery = 312;
         public const int SubTaskQuery = 322;
         public const int CarServiceWorkQuery = 329;
         public const int OfficeEquipmentQuery = 335;
         public const int CarQuery = 345;
    }

    /// <summary>
    ///     Domain objects' property keys
    /// </summary>
    public abstract class DomainObjectPropertyKeys
    {
        /// <summary>
        ///     Property keys for SysUserPermissionsDisplayView
        /// </summary>
        public abstract class SysUserPermissionsDisplayView
        {
             public const int UserId = 2;
             public const int PermissionId = 3;
             public const int PermissionName = 4;
             public const int Roles = 5;
        }
        /// <summary>
        ///     Property keys for SysOperation
        /// </summary>
        public abstract class SysOperation
        {
             public const int Id = 7;
             public const int ActionId = 9;
             public const int Date = 10;
             public const int OperationDetails = 11;
             public const int OperationResultId = 13;
             public const int Request = 14;
             public const int RequestContent = 15;
             public const int UserID = 17;
        }
        /// <summary>
        ///     Property keys for CarWorkType
        /// </summary>
        public abstract class CarWorkType
        {
             public const int Id = 22;
             public const int Name = 23;
        }
        /// <summary>
        ///     Property keys for SysObject
        /// </summary>
        public abstract class SysObject
        {
             public const int Id = 25;
             public const int ClassId = 26;
             public const int CodeName = 27;
             public const int DbFieldId = 28;
             public const int DbObjectId = 29;
             public const int Description = 30;
             public const int DisplayName = 31;
             public const int Guid = 32;
             public const int ParentId = 33;
        }
        /// <summary>
        ///     Property keys for SysOperationResult
        /// </summary>
        public abstract class SysOperationResult
        {
             public const int Id = 36;
             public const int Name = 37;
        }
        /// <summary>
        ///     Property keys for Office
        /// </summary>
        public abstract class Office
        {
             public const int Id = 42;
             public const int Adress = 43;
        }
        /// <summary>
        ///     Property keys for CarArrivalReasonType
        /// </summary>
        public abstract class CarArrivalReasonType
        {
             public const int Id = 48;
             public const int Name = 49;
        }
        /// <summary>
        ///     Property keys for SysResetPasswordToken
        /// </summary>
        public abstract class SysResetPasswordToken
        {
             public const int Id = 54;
             public const int IsExecuted = 55;
             public const int Token = 57;
             public const int UserId = 58;
             public const int ValidFrom = 59;
        }
        /// <summary>
        ///     Property keys for SysRefreshToken
        /// </summary>
        public abstract class SysRefreshToken
        {
             public const int UserId = 61;
             public const int ClientId = 62;
             public const int ExpiresUtc = 63;
             public const int Token = 65;
        }
        /// <summary>
        ///     Property keys for SysRole
        /// </summary>
        public abstract class SysRole
        {
             public const int Id = 70;
             public const int Description = 71;
             public const int IsOwnByUser = 72;
             public const int IsSystem = 73;
             public const int Name = 74;
             public const int OwnerUserID = 76;
        }
        /// <summary>
        ///     Property keys for SysUser
        /// </summary>
        public abstract class SysUser
        {
             public const int Id = 79;
             public const int AccountName = 80;
             public const int CreateDate = 81;
             public const int DeactivationDate = 82;
             public const int Description = 83;
             public const int DisplayName = 84;
             public const int EMail = 85;
             public const int EmailToken = 86;
             public const int FullAccess = 87;
             public const int IsAnonymous = 88;
             public const int IsDeactivated = 89;
             public const int IsEmailConfirmed = 90;
             public const int IsSystemUser = 91;
             public const int PasswordHash = 92;
        }
        /// <summary>
        ///     Property keys for CarServiceWork
        /// </summary>
        public abstract class CarServiceWork
        {
             public const int Id = 98;
             public const int CarServiceId = 100;
             public const int CarWorkTypeId = 102;
             public const int Comments = 103;
        }
        /// <summary>
        ///     Property keys for SysRolePermission
        /// </summary>
        public abstract class SysRolePermission
        {
             public const int Id = 105;
             public const int PermissionId = 106;
             public const int RoleId = 107;
        }
        /// <summary>
        ///     Property keys for Car
        /// </summary>
        public abstract class Car
        {
             public const int Id = 114;
             public const int CarModelId = 116;
             public const int Description = 117;
             public const int Number = 118;
        }
        /// <summary>
        ///     Property keys for SubTask
        /// </summary>
        public abstract class SubTask
        {
             public const int Id = 123;
             public const int Description = 124;
             public const int Name = 126;
             public const int Sequence = 127;
             public const int TaskId = 128;
        }
        /// <summary>
        ///     Property keys for CarModelPart
        /// </summary>
        public abstract class CarModelPart
        {
             public const int Id = 133;
             public const int CarModelId = 135;
             public const int Name = 136;
             public const int Price = 137;
        }
        /// <summary>
        ///     Property keys for SysOperationLock
        /// </summary>
        public abstract class SysOperationLock
        {
             public const int OperationName = 142;
             public const int OperationContext = 143;
             public const int AquiredTime = 144;
             public const int ExpirationTime = 145;
             public const int MachineName = 146;
             public const int ProcessId = 147;
             public const int UserId = 149;
        }
        /// <summary>
        ///     Property keys for SysUserRole
        /// </summary>
        public abstract class SysUserRole
        {
             public const int Id = 151;
             public const int RoleId = 152;
             public const int UserId = 155;
        }
        /// <summary>
        ///     Property keys for CarService
        /// </summary>
        public abstract class CarService
        {
             public const int Id = 160;
             public const int CarArrivalReasonTypeId = 163;
             public const int CarId = 164;
             public const int Conclusion = 165;
             public const int Defect = 166;
             public const int EndDate = 167;
             public const int Odometer = 168;
             public const int StartDate = 169;
        }
        /// <summary>
        ///     Property keys for OfiiceEmployee
        /// </summary>
        public abstract class OfiiceEmployee
        {
             public const int Id = 174;
             public const int Name = 175;
             public const int OfficeId = 177;
        }
        /// <summary>
        ///     Property keys for SysPermission
        /// </summary>
        public abstract class SysPermission
        {
             public const int Id = 179;
             public const int CodeName = 180;
             public const int Description = 181;
             public const int DisplayName = 182;
             public const int Guid = 183;
             public const int ObjectId = 184;
             public const int Type = 187;
        }
        /// <summary>
        ///     Property keys for SysSetting
        /// </summary>
        public abstract class SysSetting
        {
             public const int Id = 192;
             public const int SettingPropertyId = 193;
             public const int StringValue = 194;
             public const int UserId = 197;
        }
        /// <summary>
        ///     Property keys for MainTask
        /// </summary>
        public abstract class MainTask
        {
             public const int Id = 202;
             public const int Comments = 203;
             public const int CreationDate = 204;
             public const int EmployeeId = 206;
             public const int EndDate = 207;
             public const int IsCompleted = 208;
             public const int Name = 209;
        }
        /// <summary>
        ///     Property keys for OfficeEquipment
        /// </summary>
        public abstract class OfficeEquipment
        {
             public const int Id = 214;
             public const int Description = 215;
             public const int InventoryNumber = 216;
             public const int OfficeEmployeeId = 218;
             public const int OfficeEquipmentModelId = 220;
             public const int OfficeId = 221;
             public const int PlacementDate = 223;
             public const int Quontity = 224;
        }
        /// <summary>
        ///     Property keys for SysInfo
        /// </summary>
        public abstract class SysInfo
        {
             public const int SystemVersion = 226;
             public const int DomainVersion = 227;
             public const int LastInitialization = 228;
        }
        /// <summary>
        ///     Property keys for CarServicePart
        /// </summary>
        public abstract class CarServicePart
        {
             public const int Id = 233;
             public const int CarModelPartId = 235;
             public const int CarServiceId = 237;
             public const int Quantity = 238;
        }
        /// <summary>
        ///     Property keys for SysObjectType
        /// </summary>
        public abstract class SysObjectType
        {
             public const int Id = 240;
             public const int Name = 241;
        }
        /// <summary>
        ///     Property keys for MethodicalToolkit
        /// </summary>
        public abstract class MethodicalToolkit
        {
             public const int Id = 246;
             public const int Name = 247;
        }
        /// <summary>
        ///     Property keys for SysObjectClass
        /// </summary>
        public abstract class SysObjectClass
        {
             public const int Id = 249;
             public const int CodeName = 250;
             public const int Description = 251;
             public const int DisplayName = 252;
        }
        /// <summary>
        ///     Property keys for SysPermissionType
        /// </summary>
        public abstract class SysPermissionType
        {
             public const int Id = 254;
             public const int CodeName = 255;
             public const int Description = 256;
             public const int DisplayName = 257;
        }
        /// <summary>
        ///     Property keys for SysSettingProperty
        /// </summary>
        public abstract class SysSettingProperty
        {
             public const int Id = 262;
             public const int DefaultType = 263;
             public const int Description = 264;
             public const int GroupName = 265;
             public const int IsManaged = 266;
             public const int IsOverridable = 267;
             public const int Name = 268;
             public const int UIEditorType = 269;
        }
        /// <summary>
        ///     Property keys for SysUsersDisplayView
        /// </summary>
        public abstract class SysUsersDisplayView
        {
             public const int Id = 271;
             public const int UserRoleId = 273;
        }
        /// <summary>
        ///     Property keys for CarModel
        /// </summary>
        public abstract class CarModel
        {
             public const int Id = 278;
             public const int FuelConsumption = 279;
             public const int Name = 280;
        }
        /// <summary>
        ///     Property keys for MethodicalToolkitFile
        /// </summary>
        public abstract class MethodicalToolkitFile
        {
             public const int Id = 285;
             public const int Description = 286;
             public const int MethodicalToolkitId = 288;
             public const int Name = 289;
        }
        /// <summary>
        ///     Property keys for OfficeEquipmentModel
        /// </summary>
        public abstract class OfficeEquipmentModel
        {
             public const int Id = 294;
             public const int Name = 295;
        }
        /// <summary>
        ///     Property keys for MainTaskQuery
        /// </summary>
        public abstract class MainTaskQuery
        {
             public const int Id = 297;
             public const int Comments = 298;
             public const int CreationDate = 299;
             public const int Employee_Name = 300;
             public const int EmployeeId = 301;
             public const int EndDate = 302;
             public const int IsCompleted = 303;
             public const int Name = 304;
        }
        /// <summary>
        ///     Property keys for CarServicePartQuery
        /// </summary>
        public abstract class CarServicePartQuery
        {
             public const int Id = 306;
             public const int CarModelPart_Name = 307;
             public const int CarModelPart_Price = 308;
             public const int CarModelPartId = 309;
             public const int CarServiceId = 310;
             public const int Quantity = 311;
        }
        /// <summary>
        ///     Property keys for CarServiceQuery
        /// </summary>
        public abstract class CarServiceQuery
        {
             public const int Id = 313;
             public const int CarArrivalReasonType_Name = 314;
             public const int CarArrivalReasonTypeId = 315;
             public const int CarId = 316;
             public const int Conclusion = 317;
             public const int Defect = 318;
             public const int EndDate = 319;
             public const int Odometer = 320;
             public const int StartDate = 321;
        }
        /// <summary>
        ///     Property keys for SubTaskQuery
        /// </summary>
        public abstract class SubTaskQuery
        {
             public const int Id = 323;
             public const int Description = 324;
             public const int MainTask_Employee_Name = 325;
             public const int Name = 326;
             public const int Sequence = 327;
             public const int TaskId = 328;
        }
        /// <summary>
        ///     Property keys for CarServiceWorkQuery
        /// </summary>
        public abstract class CarServiceWorkQuery
        {
             public const int Id = 330;
             public const int CarServiceId = 331;
             public const int CarWorkType_Name = 332;
             public const int CarWorkTypeId = 333;
             public const int Comments = 334;
        }
        /// <summary>
        ///     Property keys for OfficeEquipmentQuery
        /// </summary>
        public abstract class OfficeEquipmentQuery
        {
             public const int Id = 336;
             public const int Description = 337;
             public const int InventoryNumber = 338;
             public const int OfficeEquipmentModel_Name = 339;
             public const int OfficeEquipmentModelId = 340;
             public const int OfficeId = 341;
             public const int OfiiceEmployee_Name = 342;
             public const int PlacementDate = 343;
             public const int Quontity = 344;
        }
        /// <summary>
        ///     Property keys for CarQuery
        /// </summary>
        public abstract class CarQuery
        {
             public const int Id = 346;
             public const int CarModel_FuelConsumption = 347;
             public const int CarModel_Name = 348;
             public const int CarModelId = 349;
             public const int Description = 350;
             public const int Number = 351;
        }
    }
}