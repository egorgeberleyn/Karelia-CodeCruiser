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
    public partial class SysRole : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysRole; }
        }

        public SysRole()
		{
            IsOwnByUser = false;
            IsSystem = false;
		}	
        public virtual string Description { get; set; }

        public virtual bool IsOwnByUser { get; set; }

        public virtual bool IsSystem { get; set; }

        public virtual string Name { get; set; }

        [JsonIgnore]
        public virtual SysUser OwnerUser { get; set; }

        public virtual int? OwnerUserID { get; set; }

        [JsonIgnore]
        public virtual ICollection<SysRolePermission> SysRolePermissions { get; set; }

        
		public SysRole Clone()
        {
            var obj = new SysRole
            {
                Description = Description,
                IsOwnByUser = IsOwnByUser,
                IsSystem = IsSystem,
                Name = Name,
                OwnerUserID = OwnerUserID,
            };

            if (IsNew())
            {
                if(OwnerUser != null && OwnerUser.IsNew())  
                {
                   obj.OwnerUser = OwnerUser;
                }
            }
            return obj;
        }
    }
}