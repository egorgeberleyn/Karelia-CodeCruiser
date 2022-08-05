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
    public partial class CarServicePartQuery : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.CarServicePartQuery; }
        }

        public CarServicePartQuery()
		{
		}	
        public virtual string CarModelPart_Name { get; set; }

        public virtual decimal? CarModelPart_Price { get; set; }

        public virtual int CarModelPartId { get; set; }

        public virtual int CarServiceId { get; set; }

        public virtual int Quantity { get; set; }

        
		public CarServicePartQuery Clone()
        {
            var obj = new CarServicePartQuery
            {
                CarModelPart_Name = CarModelPart_Name,
                CarModelPart_Price = CarModelPart_Price,
                CarModelPartId = CarModelPartId,
                CarServiceId = CarServiceId,
                Quantity = Quantity,
            };

            return obj;
        }
    }
}