using System;
using System.Collections.Generic;
using BusinessFramework.Contracts;
using BusinessFramework.Contracts.DataObjects;
using BusinessFramework.WebAPI.Contracts.DataObjects;
using BusinessFramework.WebAPI.Contracts.Metadata;
using Karelia.Contracts.DataObjects;
using Newtonsoft.Json;

namespace Karelia.WebAPI.Contracts.DataObjects
{    
    public partial class SysUserPermissionsDisplayView : AbstractApiEntity<SysUserPermissionsDisplayViewKey>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysUserPermissionsDisplayView; }
        }

        public SysUserPermissionsDisplayView()
		{
		}	
        public virtual int UserId { get; set; }

        public virtual int PermissionId { get; set; }

        public virtual string PermissionName { get; set; }

        public virtual string Roles { get; set; }

        public override SysUserPermissionsDisplayViewKey GetKey()
        {
            return new SysUserPermissionsDisplayViewKey(UserId, PermissionId);
            
        }
        
		public bool IsNew()
        {
		    return Equals(UserId, default(int)) && Equals(PermissionId, default(int));
        }
        
		public SysUserPermissionsDisplayView Clone()
        {
            var obj = new SysUserPermissionsDisplayView
            {
                PermissionName = PermissionName,
                Roles = Roles,
            };

            return obj;
        }
    }
}