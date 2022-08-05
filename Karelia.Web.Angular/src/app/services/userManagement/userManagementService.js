export function managePermissions(services, roleId, roleName) {
  return services.httpService.post(`serverusermanagementservice/getmanagepermissions?roleId=${roleId}`).then(result => {
    return services.modalWindowService.show({
      template: '<multi-select-list-form items="permissions"><multi-select-list-form/>',
      title: `${services.$translate.instant('multiselect_list_form_header')} '${roleName}'`,
      locals: {
        permissions: result.data.Data
      }
    }).promise.then((permissions) => {
      return services.httpService.postModel(`serverusermanagementservice/savepermissions?roleId=${roleId}`, permissions.filter(p => p.Checked).map(p => p.Id));
    });
  });
}

export function manageRoles(services, userId,  userName) {
	return services.httpService.post(`serverusermanagementservice/getmanageroles?userId=${userId}`).then(result => {
		return services.modalWindowService.show({
			template: '<multi-select-list-form items="roles"><multi-select-list-form/>',
      title: `${services.$translate.instant('multiselect_list_form_header')} '${userName}'`,
      locals: {
        roles: result.data.Data
      }
		}).promise.then((roles) => {
			return services.httpService.postModel(`serverusermanagementservice/saveroles?userId=${userId}`, roles.filter(p => p.Checked).map(p => p.Id));			
		});
	})
}

export function manageUsers(services, roleId,  roleName) {
	return services.httpService.post(`serverusermanagementservice/getmanageusers?roleId=${roleId}`).then(result => {
		return services.modalWindowService.show({
			template: '<multi-select-list-form items="users"><multi-select-list-form/>',
      title: `${services.$translate.instant('multiselect_list_form_header')} '${roleName}'`,
      locals: {
        users: result.data.Data
      }
		}).promise.then((users) => {
			return services.httpService.postModel(`serverusermanagementservice/saveusers?roleId=${roleId}`, users.filter(p => p.Checked).map(p => p.Id));			
		});
	})
}
