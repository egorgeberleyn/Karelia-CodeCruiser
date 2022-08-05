import CodeBehindClientUserManagementService from './codeBehind/codeBehindClientUserManagementService';
import { managePermissions, manageRoles, manageUsers } from "../../services/userManagement/userManagementService";

export default class ClientUserManagementService extends CodeBehindClientUserManagementService {
	constructor(
    services,
		//--  custom dependencies
		//-- /custom dependencies
		customActionRunner){
		"ngInject";
    super(customActionRunner);
    this.services = services;
  }
  
  managePermissions ( roleId,  roleName){
    return managePermissions(this.services, roleId, roleName);
	}
	manageRoles ( userId,  userName){
		return manageRoles(this.services, userId, userName);
	}
	manageUsers ( roleId,  roleName){
		return manageUsers(this.services, roleId, roleName);
	}
}
