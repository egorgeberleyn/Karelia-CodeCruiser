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
    public partial class CarServiceWorkQuery : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.CarServiceWorkQuery; }
        }

        public CarServiceWorkQuery()
		{
		}	
        public virtual int CarServiceId { get; set; }

        public virtual string CarWorkType_Name { get; set; }

        public virtual int CarWorkTypeId { get; set; }

        public virtual string Comments { get; set; }

        
		public CarServiceWorkQuery Clone()
        {
            var obj = new CarServiceWorkQuery
            {
                CarServiceId = CarServiceId,
                CarWorkType_Name = CarWorkType_Name,
                CarWorkTypeId = CarWorkTypeId,
                Comments = Comments,
            };

            return obj;
        }
    }
}