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
    public partial class CarModel : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.CarModel; }
        }

        public CarModel()
		{
		}	
        public virtual double? FuelConsumption { get; set; }

        public virtual string Name { get; set; }

        
		public CarModel Clone()
        {
            var obj = new CarModel
            {
                FuelConsumption = FuelConsumption,
                Name = Name,
            };

            if (IsNew())
            {
            }
            return obj;
        }
    }
}