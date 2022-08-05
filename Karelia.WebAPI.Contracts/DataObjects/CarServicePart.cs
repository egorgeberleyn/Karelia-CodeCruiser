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
    public partial class CarServicePart : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.CarServicePart; }
        }

        public CarServicePart()
		{
		}	
        [JsonIgnore]
        public virtual CarModelPart CarModelPart { get; set; }

        public virtual int CarModelPartId { get; set; }

        [JsonIgnore]
        public virtual CarService CarService { get; set; }

        public virtual int CarServiceId { get; set; }

        public virtual int Quantity { get; set; }

        
		public CarServicePart Clone()
        {
            var obj = new CarServicePart
            {
                CarModelPartId = CarModelPartId,
                CarServiceId = CarServiceId,
                Quantity = Quantity,
            };

            if (IsNew())
            {
                if(CarModelPart != null && CarModelPart.IsNew())  
                {
                   obj.CarModelPart = CarModelPart;
                }
                if(CarService != null && CarService.IsNew())  
                {
                   obj.CarService = CarService;
                }
            }
            return obj;
        }
    }
}