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
    public partial class SysUsersDisplayView : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysUsersDisplayView; }
        }

        public SysUsersDisplayView()
		{
		}	
        [JsonIgnore]
        public virtual SysUser SysUser { get; set; }

        public virtual int? UserRoleId { get; set; }

        
		public SysUsersDisplayView Clone()
        {
            var obj = new SysUsersDisplayView
            {
                UserRoleId = UserRoleId,
            };

            if (IsNew())
            {
                if(SysUser != null && SysUser.IsNew())  
                {
                   obj.SysUser = SysUser;
                }
            }
            return obj;
        }
    }
}