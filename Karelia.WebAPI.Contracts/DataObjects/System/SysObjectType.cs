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
    public partial class SysObjectType : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysObjectType; }
        }

        public SysObjectType()
		{
		}	
        public virtual string Name { get; set; }

        
		public SysObjectType Clone()
        {
            var obj = new SysObjectType
            {
                Name = Name,
            };

            if (IsNew())
            {
            }
            return obj;
        }
    }
}