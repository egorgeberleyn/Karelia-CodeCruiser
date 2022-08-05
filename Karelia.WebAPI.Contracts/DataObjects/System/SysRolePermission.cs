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
    public partial class SysRolePermission : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysRolePermission; }
        }

        public SysRolePermission()
		{
		}	
        public virtual int PermissionId { get; set; }

        public virtual int RoleId { get; set; }

        [JsonIgnore]
        public virtual SysPermission SysPermission { get; set; }

        [JsonIgnore]
        public virtual SysRole SysRole { get; set; }

        
		public SysRolePermission Clone()
        {
            var obj = new SysRolePermission
            {
                PermissionId = PermissionId,
                RoleId = RoleId,
            };

            if (IsNew())
            {
                if(SysPermission != null && SysPermission.IsNew())  
                {
                   obj.SysPermission = SysPermission;
                }
                if(SysRole != null && SysRole.IsNew())  
                {
                   obj.SysRole = SysRole;
                }
            }
            return obj;
        }
    }
}