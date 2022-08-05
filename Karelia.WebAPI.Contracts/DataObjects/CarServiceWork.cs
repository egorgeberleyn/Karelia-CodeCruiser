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
    public partial class CarServiceWork : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.CarServiceWork; }
        }

        public CarServiceWork()
		{
		}	
        [JsonIgnore]
        public virtual CarService CarService { get; set; }

        public virtual int CarServiceId { get; set; }

        [JsonIgnore]
        public virtual CarWorkType CarWorkType { get; set; }

        public virtual int CarWorkTypeId { get; set; }

        public virtual string Comments { get; set; }

        
		public CarServiceWork Clone()
        {
            var obj = new CarServiceWork
            {
                CarServiceId = CarServiceId,
                CarWorkTypeId = CarWorkTypeId,
                Comments = Comments,
            };

            if (IsNew())
            {
                if(CarService != null && CarService.IsNew())  
                {
                   obj.CarService = CarService;
                }
                if(CarWorkType != null && CarWorkType.IsNew())  
                {
                   obj.CarWorkType = CarWorkType;
                }
            }
            return obj;
        }
    }
}