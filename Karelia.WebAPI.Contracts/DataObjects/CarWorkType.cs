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
    public partial class CarWorkType : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.CarWorkType; }
        }

        public CarWorkType()
		{
		}	
        public virtual string Name { get; set; }

        
		public CarWorkType Clone()
        {
            var obj = new CarWorkType
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