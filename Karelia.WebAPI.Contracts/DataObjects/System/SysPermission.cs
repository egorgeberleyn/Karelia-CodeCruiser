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
    public partial class SysPermission : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysPermission; }
        }

        public SysPermission()
		{
		}	
        public virtual string CodeName { get; set; }

        public virtual string Description { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual Guid Guid { get; set; }

        public virtual int ObjectId { get; set; }

        [JsonIgnore]
        public virtual SysObject SysObject { get; set; }

        [JsonIgnore]
        public virtual SysPermissionType SysPermissionType { get; set; }

        public virtual byte Type { get; set; }

        
		public SysPermission Clone()
        {
            var obj = new SysPermission
            {
                CodeName = CodeName,
                Description = Description,
                DisplayName = DisplayName,
                Guid = Guid,
                ObjectId = ObjectId,
                Type = Type,
            };

            if (IsNew())
            {
                if(SysObject != null && SysObject.IsNew())  
                {
                   obj.SysObject = SysObject;
                }
                if(SysPermissionType != null && SysPermissionType.IsNew())  
                {
                   obj.SysPermissionType = SysPermissionType;
                }
            }
            return obj;
        }
    }
}