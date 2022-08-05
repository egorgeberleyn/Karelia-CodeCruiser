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
    public partial class SysUserRole : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysUserRole; }
        }

        public SysUserRole()
		{
		}	
        public virtual int RoleId { get; set; }

        [JsonIgnore]
        public virtual SysRole SysRole { get; set; }

        [JsonIgnore]
        public virtual SysUser SysUser { get; set; }

        public virtual int UserId { get; set; }

        
		public SysUserRole Clone()
        {
            var obj = new SysUserRole
            {
                RoleId = RoleId,
                UserId = UserId,
            };

            if (IsNew())
            {
                if(SysRole != null && SysRole.IsNew())  
                {
                   obj.SysRole = SysRole;
                }
                if(SysUser != null && SysUser.IsNew())  
                {
                   obj.SysUser = SysUser;
                }
            }
            return obj;
        }
    }
}