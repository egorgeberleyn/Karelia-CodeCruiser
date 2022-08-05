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
    public partial class CarQuery : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.CarQuery; }
        }

        public CarQuery()
		{
		}	
        public virtual double? CarModel_FuelConsumption { get; set; }

        public virtual string CarModel_Name { get; set; }

        public virtual int CarModelId { get; set; }

        public virtual string Description { get; set; }

        public virtual string Number { get; set; }

        
		public CarQuery Clone()
        {
            var obj = new CarQuery
            {
                CarModel_FuelConsumption = CarModel_FuelConsumption,
                CarModel_Name = CarModel_Name,
                CarModelId = CarModelId,
                Description = Description,
                Number = Number,
            };

            return obj;
        }
    }
}