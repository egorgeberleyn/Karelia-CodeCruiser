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
    public partial class OfiiceEmployee : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.OfiiceEmployee; }
        }

        public OfiiceEmployee()
		{
		}	
        public virtual string Name { get; set; }

        [JsonIgnore]
        public virtual Office Office { get; set; }

        public virtual int OfficeId { get; set; }

        
		public OfiiceEmployee Clone()
        {
            var obj = new OfiiceEmployee
            {
                Name = Name,
                OfficeId = OfficeId,
            };

            if (IsNew())
            {
                if(Office != null && Office.IsNew())  
                {
                   obj.Office = Office;
                }
            }
            return obj;
        }
    }
}