using System;
using System.Collections.Generic;
using BusinessFramework.Contracts;
using BusinessFramework.Contracts.DataObjects;
using BusinessFramework.WebAPI.Contracts.DataObjects;
using BusinessFramework.WebAPI.Contracts.Metadata;
using Karelia.Contracts.DataObjects;
using Karelia.Contracts.Enums;
using Newtonsoft.Json;

namespace Karelia.WebAPI.Contracts.DataObjects
{    
    public partial class SysOperationResult : ClassicApiEntity<byte>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysOperationResult; }
        }

        public SysOperationResult()
		{
		}	
        public virtual string Name { get; set; }

        
		public SysOperationResult Clone()
        {
            var obj = new SysOperationResult
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