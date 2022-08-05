import angular from "angular"
import registerCustomComponents from './registerCustomComponents'
import CarModelsService from "./screens/carModelsService"
import CarsService from "./screens/carsService"
import WorksService from "./screens/worksService"
import TasksService from "./screens/tasksService"
import ModelEquipmentsService from "./screens/modelEquipmentsService"
import OfficeService from "./screens/officeService"
import CarWizardFactory from "./wizards/objectFactories/carWizardFactory"
import CarWizardService from "./wizards/carWizardService"
import CarWizardInitialization from "./wizards/initialization/carWizardInitialization"
import CarModelWizardFactory from "./wizards/objectFactories/carModelWizardFactory"
import CarModelWizardService from "./wizards/carModelWizardService"
import CarModelWizardInitialization from "./wizards/initialization/carModelWizardInitialization"
import CarModelPartWizardFactory from "./wizards/objectFactories/carModelPartWizardFactory"
import CarModelPartWizardService from "./wizards/carModelPartWizardService"
import CarModelPartWizardInitialization from "./wizards/initialization/carModelPartWizardInitialization"
import CarServiceWizardFactory from "./wizards/objectFactories/carServiceWizardFactory"
import CarServiceWizardService from "./wizards/carServiceWizardService"
import CarServiceWizardInitialization from "./wizards/initialization/carServiceWizardInitialization"
import CarServicePartWizardFactory from "./wizards/objectFactories/carServicePartWizardFactory"
import CarServicePartWizardService from "./wizards/carServicePartWizardService"
import CarServicePartWizardInitialization from "./wizards/initialization/carServicePartWizardInitialization"
import CarServiceWorkWizardFactory from "./wizards/objectFactories/carServiceWorkWizardFactory"
import CarServiceWorkWizardService from "./wizards/carServiceWorkWizardService"
import CarServiceWorkWizardInitialization from "./wizards/initialization/carServiceWorkWizardInitialization"
import MainTaskWizardFactory from "./wizards/objectFactories/mainTaskWizardFactory"
import MainTaskWizardService from "./wizards/mainTaskWizardService"
import MainTaskWizardInitialization from "./wizards/initialization/mainTaskWizardInitialization"
import SubTaskWizardFactory from "./wizards/objectFactories/subTaskWizardFactory"
import SubTaskWizardService from "./wizards/subTaskWizardService"
import SubTaskWizardInitialization from "./wizards/initialization/subTaskWizardInitialization"
import OfficeWizardFactory from "./wizards/objectFactories/officeWizardFactory"
import OfficeWizardService from "./wizards/officeWizardService"
import OfficeWizardInitialization from "./wizards/initialization/officeWizardInitialization"
import OfficeEquipmentWizardFactory from "./wizards/objectFactories/officeEquipmentWizardFactory"
import OfficeEquipmentWizardService from "./wizards/officeEquipmentWizardService"
import OfficeEquipmentWizardInitialization from "./wizards/initialization/officeEquipmentWizardInitialization"
import OfficeEmployeeWizardFactory from "./wizards/objectFactories/officeEmployeeWizardFactory"
import OfficeEmployeeWizardService from "./wizards/officeEmployeeWizardService"
import OfficeEmployeeWizardInitialization from "./wizards/initialization/officeEmployeeWizardInitialization"
import OfficeEquipmentModelWizardFactory from "./wizards/objectFactories/officeEquipmentModelWizardFactory"
import OfficeEquipmentModelWizardService from "./wizards/officeEquipmentModelWizardService"
import OfficeEquipmentModelWizardInitialization from "./wizards/initialization/officeEquipmentModelWizardInitialization"
import CarValidationService from "./validation/carValidationService"
import CarModelValidationService from "./validation/carModelValidationService"
import CarModelPartValidationService from "./validation/carModelPartValidationService"
import CarServiceValidationService from "./validation/carServiceValidationService"
import CarServicePartValidationService from "./validation/carServicePartValidationService"
import CarServiceWorkValidationService from "./validation/carServiceWorkValidationService"
import MainTaskValidationService from "./validation/mainTaskValidationService"
import SubTaskValidationService from "./validation/subTaskValidationService"
import OfficeValidationService from "./validation/officeValidationService"
import OfficeEquipmentValidationService from "./validation/officeEquipmentValidationService"
import OfiiceEmployeeValidationService from "./validation/ofiiceEmployeeValidationService"
import OfficeEquipmentModelValidationService from "./validation/officeEquipmentModelValidationService"
import OperationResultEnum from "./enums/operationResultEnum"
import EnumsService from "./enums/enumsService"

const app = angular.module("app.domain", []);

app.service("carModelsService", CarModelsService);
app.service("carsService", CarsService);
app.service("worksService", WorksService);
app.service("tasksService", TasksService);
app.service("modelEquipmentsService", ModelEquipmentsService);
app.service("officeService", OfficeService);
app.service("carWizardFactory", CarWizardFactory);
app.service("carWizardService", CarWizardService);
app.service("carWizardInitialization", CarWizardInitialization);
app.service("carModelWizardFactory", CarModelWizardFactory);
app.service("carModelWizardService", CarModelWizardService);
app.service("carModelWizardInitialization", CarModelWizardInitialization);
app.service("carModelPartWizardFactory", CarModelPartWizardFactory);
app.service("carModelPartWizardService", CarModelPartWizardService);
app.service("carModelPartWizardInitialization", CarModelPartWizardInitialization);
app.service("carServiceWizardFactory", CarServiceWizardFactory);
app.service("carServiceWizardService", CarServiceWizardService);
app.service("carServiceWizardInitialization", CarServiceWizardInitialization);
app.service("carServicePartWizardFactory", CarServicePartWizardFactory);
app.service("carServicePartWizardService", CarServicePartWizardService);
app.service("carServicePartWizardInitialization", CarServicePartWizardInitialization);
app.service("carServiceWorkWizardFactory", CarServiceWorkWizardFactory);
app.service("carServiceWorkWizardService", CarServiceWorkWizardService);
app.service("carServiceWorkWizardInitialization", CarServiceWorkWizardInitialization);
app.service("mainTaskWizardFactory", MainTaskWizardFactory);
app.service("mainTaskWizardService", MainTaskWizardService);
app.service("mainTaskWizardInitialization", MainTaskWizardInitialization);
app.service("subTaskWizardFactory", SubTaskWizardFactory);
app.service("subTaskWizardService", SubTaskWizardService);
app.service("subTaskWizardInitialization", SubTaskWizardInitialization);
app.service("officeWizardFactory", OfficeWizardFactory);
app.service("officeWizardService", OfficeWizardService);
app.service("officeWizardInitialization", OfficeWizardInitialization);
app.service("officeEquipmentWizardFactory", OfficeEquipmentWizardFactory);
app.service("officeEquipmentWizardService", OfficeEquipmentWizardService);
app.service("officeEquipmentWizardInitialization", OfficeEquipmentWizardInitialization);
app.service("officeEmployeeWizardFactory", OfficeEmployeeWizardFactory);
app.service("officeEmployeeWizardService", OfficeEmployeeWizardService);
app.service("officeEmployeeWizardInitialization", OfficeEmployeeWizardInitialization);
app.service("officeEquipmentModelWizardFactory", OfficeEquipmentModelWizardFactory);
app.service("officeEquipmentModelWizardService", OfficeEquipmentModelWizardService);
app.service("officeEquipmentModelWizardInitialization", OfficeEquipmentModelWizardInitialization);
app.service("carValidationService", CarValidationService);
app.service("carModelValidationService", CarModelValidationService);
app.service("carModelPartValidationService", CarModelPartValidationService);
app.service("carServiceValidationService", CarServiceValidationService);
app.service("carServicePartValidationService", CarServicePartValidationService);
app.service("carServiceWorkValidationService", CarServiceWorkValidationService);
app.service("mainTaskValidationService", MainTaskValidationService);
app.service("subTaskValidationService", SubTaskValidationService);
app.service("officeValidationService", OfficeValidationService);
app.service("officeEquipmentValidationService", OfficeEquipmentValidationService);
app.service("ofiiceEmployeeValidationService", OfiiceEmployeeValidationService);
app.service("officeEquipmentModelValidationService", OfficeEquipmentModelValidationService);
app.service("operationResultEnum", OperationResultEnum);
app.service("enumsService", EnumsService);
registerCustomComponents(app);