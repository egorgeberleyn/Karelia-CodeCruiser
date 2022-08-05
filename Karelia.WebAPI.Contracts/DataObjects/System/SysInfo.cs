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
    public partial class SysInfo : AbstractApiEntity<SysInfoKey>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysInfo; }
        }

        public SysInfo()
		{
		}	
        public virtual string SystemVersion { get; set; }

        public virtual string DomainVersion { get; set; }

        public virtual DateTime LastInitialization { get; set; }

        public override SysInfoKey GetKey()
        {
            return new SysInfoKey(SystemVersion, DomainVersion, LastInitialization);
            
        }
        
		public bool IsNew()
        {
		    return Equals(SystemVersion, default(string)) && Equals(DomainVersion, default(string)) && Equals(LastInitialization, default(DateTime));
        }
        
		public SysInfo Clone()
        {
            var obj = new SysInfo
            {
            };

            return obj;
        }
    }
}