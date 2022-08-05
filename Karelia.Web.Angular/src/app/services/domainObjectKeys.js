(function() {
    'use strict';
	class DomainObjectKeysService {
		constructor() {}
		getPropertyNameById (propertyId) {
			if (22 === propertyId)
				return "Id";
			if (23 === propertyId)
				return "Name";
			if (42 === propertyId)
				return "Id";
			if (43 === propertyId)
				return "Adress";
			if (48 === propertyId)
				return "Id";
			if (49 === propertyId)
				return "Name";
			if (54 === propertyId)
				return "Id";
			if (55 === propertyId)
				return "IsExecuted";
			if (57 === propertyId)
				return "Token";
			if (58 === propertyId)
				return "UserId";
			if (59 === propertyId)
				return "ValidFrom";
			if (70 === propertyId)
				return "Id";
			if (71 === propertyId)
				return "Description";
			if (72 === propertyId)
				return "IsOwnByUser";
			if (73 === propertyId)
				return "IsSystem";
			if (74 === propertyId)
				return "Name";
			if (76 === propertyId)
				return "OwnerUserID";
			if (98 === propertyId)
				return "Id";
			if (100 === propertyId)
				return "CarServiceId";
			if (102 === propertyId)
				return "CarWorkTypeId";
			if (103 === propertyId)
				return "Comments";
			if (114 === propertyId)
				return "Id";
			if (116 === propertyId)
				return "CarModelId";
			if (117 === propertyId)
				return "Description";
			if (118 === propertyId)
				return "Number";
			if (123 === propertyId)
				return "Id";
			if (124 === propertyId)
				return "Description";
			if (126 === propertyId)
				return "Name";
			if (127 === propertyId)
				return "Sequence";
			if (128 === propertyId)
				return "TaskId";
			if (133 === propertyId)
				return "Id";
			if (135 === propertyId)
				return "CarModelId";
			if (136 === propertyId)
				return "Name";
			if (137 === propertyId)
				return "Price";
			if (142 === propertyId)
				return "OperationName";
			if (143 === propertyId)
				return "OperationContext";
			if (144 === propertyId)
				return "AquiredTime";
			if (145 === propertyId)
				return "ExpirationTime";
			if (146 === propertyId)
				return "MachineName";
			if (147 === propertyId)
				return "ProcessId";
			if (160 === propertyId)
				return "Id";
			if (163 === propertyId)
				return "CarArrivalReasonTypeId";
			if (164 === propertyId)
				return "CarId";
			if (165 === propertyId)
				return "Conclusion";
			if (166 === propertyId)
				return "Defect";
			if (167 === propertyId)
				return "EndDate";
			if (168 === propertyId)
				return "Odometer";
			if (169 === propertyId)
				return "StartDate";
			if (174 === propertyId)
				return "Id";
			if (175 === propertyId)
				return "Name";
			if (177 === propertyId)
				return "OfficeId";
			if (192 === propertyId)
				return "Id";
			if (193 === propertyId)
				return "SettingPropertyId";
			if (194 === propertyId)
				return "StringValue";
			if (197 === propertyId)
				return "UserId";
			if (202 === propertyId)
				return "Id";
			if (203 === propertyId)
				return "Comments";
			if (204 === propertyId)
				return "CreationDate";
			if (206 === propertyId)
				return "EmployeeId";
			if (207 === propertyId)
				return "EndDate";
			if (208 === propertyId)
				return "IsCompleted";
			if (209 === propertyId)
				return "Name";
			if (214 === propertyId)
				return "Id";
			if (215 === propertyId)
				return "Description";
			if (216 === propertyId)
				return "InventoryNumber";
			if (218 === propertyId)
				return "OfficeEmployeeId";
			if (220 === propertyId)
				return "OfficeEquipmentModelId";
			if (221 === propertyId)
				return "OfficeId";
			if (223 === propertyId)
				return "PlacementDate";
			if (224 === propertyId)
				return "Quontity";
			if (233 === propertyId)
				return "Id";
			if (235 === propertyId)
				return "CarModelPartId";
			if (237 === propertyId)
				return "CarServiceId";
			if (238 === propertyId)
				return "Quantity";
			if (246 === propertyId)
				return "Id";
			if (247 === propertyId)
				return "Name";
			if (262 === propertyId)
				return "Id";
			if (263 === propertyId)
				return "DefaultType";
			if (264 === propertyId)
				return "Description";
			if (265 === propertyId)
				return "GroupName";
			if (266 === propertyId)
				return "IsManaged";
			if (267 === propertyId)
				return "IsOverridable";
			if (268 === propertyId)
				return "Name";
			if (269 === propertyId)
				return "UIEditorType";
			if (278 === propertyId)
				return "Id";
			if (279 === propertyId)
				return "FuelConsumption";
			if (280 === propertyId)
				return "Name";
			if (285 === propertyId)
				return "Id";
			if (286 === propertyId)
				return "Description";
			if (288 === propertyId)
				return "MethodicalToolkitId";
			if (289 === propertyId)
				return "Name";
			if (294 === propertyId)
				return "Id";
			if (295 === propertyId)
				return "Name";
			if (297 === propertyId)
				return "Id";
			if (298 === propertyId)
				return "Comments";
			if (299 === propertyId)
				return "CreationDate";
			if (300 === propertyId)
				return "Employee_Name";
			if (301 === propertyId)
				return "EmployeeId";
			if (302 === propertyId)
				return "EndDate";
			if (303 === propertyId)
				return "IsCompleted";
			if (304 === propertyId)
				return "Name";
			if (306 === propertyId)
				return "Id";
			if (307 === propertyId)
				return "CarModelPart_Name";
			if (308 === propertyId)
				return "CarModelPart_Price";
			if (309 === propertyId)
				return "CarModelPartId";
			if (310 === propertyId)
				return "CarServiceId";
			if (311 === propertyId)
				return "Quantity";
			if (313 === propertyId)
				return "Id";
			if (314 === propertyId)
				return "CarArrivalReasonType_Name";
			if (315 === propertyId)
				return "CarArrivalReasonTypeId";
			if (316 === propertyId)
				return "CarId";
			if (317 === propertyId)
				return "Conclusion";
			if (318 === propertyId)
				return "Defect";
			if (319 === propertyId)
				return "EndDate";
			if (320 === propertyId)
				return "Odometer";
			if (321 === propertyId)
				return "StartDate";
			if (323 === propertyId)
				return "Id";
			if (324 === propertyId)
				return "Description";
			if (325 === propertyId)
				return "MainTask_Employee_Name";
			if (326 === propertyId)
				return "Name";
			if (327 === propertyId)
				return "Sequence";
			if (328 === propertyId)
				return "TaskId";
			if (330 === propertyId)
				return "Id";
			if (331 === propertyId)
				return "CarServiceId";
			if (332 === propertyId)
				return "CarWorkType_Name";
			if (333 === propertyId)
				return "CarWorkTypeId";
			if (334 === propertyId)
				return "Comments";
			if (336 === propertyId)
				return "Id";
			if (337 === propertyId)
				return "Description";
			if (338 === propertyId)
				return "InventoryNumber";
			if (339 === propertyId)
				return "OfficeEquipmentModel_Name";
			if (340 === propertyId)
				return "OfficeEquipmentModelId";
			if (341 === propertyId)
				return "OfficeId";
			if (342 === propertyId)
				return "OfiiceEmployee_Name";
			if (343 === propertyId)
				return "PlacementDate";
			if (344 === propertyId)
				return "Quontity";
			if (346 === propertyId)
				return "Id";
			if (347 === propertyId)
				return "CarModel_FuelConsumption";
			if (348 === propertyId)
				return "CarModel_Name";
			if (349 === propertyId)
				return "CarModelId";
			if (350 === propertyId)
				return "Description";
			if (351 === propertyId)
				return "Number";
		
		}

	}
	angular.module('acsys').service('domainObjectKeysService', DomainObjectKeysService);
}).call(this);
