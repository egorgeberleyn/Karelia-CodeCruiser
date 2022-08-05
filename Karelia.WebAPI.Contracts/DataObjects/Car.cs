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
    public partial class Car : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.Car; }
        }

        public Car()
		{
		}	
        [JsonIgnore]
        public virtual CarModel CarModel { get; set; }

        public virtual int CarModelId { get; set; }

        public virtual string Description { get; set; }

        public virtual string Number { get; set; }

        
		public Car Clone()
        {
            var obj = new Car
            {
                CarModelId = CarModelId,
                Description = Description,
                Number = Number,
            };

            if (IsNew())
            {
                if(CarModel != null && CarModel.IsNew())  
                {
                   obj.CarModel = CarModel;
                }
            }
            return obj;
        }
    }
}