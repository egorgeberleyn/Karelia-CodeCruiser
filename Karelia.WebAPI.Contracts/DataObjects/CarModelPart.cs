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
    public partial class CarModelPart : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.CarModelPart; }
        }

        public CarModelPart()
		{
		}	
        [JsonIgnore]
        public virtual CarModel CarModel { get; set; }

        public virtual int CarModelId { get; set; }

        public virtual string Name { get; set; }

        public virtual decimal? Price { get; set; }

        
		public CarModelPart Clone()
        {
            var obj = new CarModelPart
            {
                CarModelId = CarModelId,
                Name = Name,
                Price = Price,
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