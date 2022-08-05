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
    public partial class CarArrivalReasonType : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.CarArrivalReasonType; }
        }

        public CarArrivalReasonType()
		{
		}	
        public virtual string Name { get; set; }

        
		public CarArrivalReasonType Clone()
        {
            var obj = new CarArrivalReasonType
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