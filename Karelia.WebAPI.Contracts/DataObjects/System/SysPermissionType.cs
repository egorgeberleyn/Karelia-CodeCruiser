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
    public partial class SysPermissionType : ClassicApiEntity<byte>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysPermissionType; }
        }

        public SysPermissionType()
		{
		}	
        public virtual string CodeName { get; set; }

        public virtual string Description { get; set; }

        public virtual string DisplayName { get; set; }

        
		public SysPermissionType Clone()
        {
            var obj = new SysPermissionType
            {
                CodeName = CodeName,
                Description = Description,
                DisplayName = DisplayName,
            };

            if (IsNew())
            {
            }
            return obj;
        }
    }
}