using System.Collections.Generic;
using Karelia.Contracts;
using Karelia.WebAPI.Contracts;


namespace Karelia.WebAPI
{
    partial class SecurityService
    {
        private PublicDomainPermissions[] GetPublicPermissions()
        {
            var permissions = new List<PublicDomainPermissions>(5);

            if (Authorize(DomainPermissions.SettingManagement))
            {
                permissions.Add(PublicDomainPermissions.SettingManagement);
            }
            if (Authorize(DomainPermissions.ReportManagement))
            {
                permissions.Add(PublicDomainPermissions.ReportManagement);
            }
            if (Authorize(DomainPermissions.NewGlobalPermission1))
            {
                permissions.Add(PublicDomainPermissions.NewGlobalPermission1);
            }
            if (Authorize(DomainPermissions.OperationLock))
            {
                permissions.Add(PublicDomainPermissions.OperationLock);
            }
            if (Authorize(DomainPermissions.Settings))
            {
                permissions.Add(PublicDomainPermissions.Settings);
            }

            return permissions.ToArray();
        }
    }
}