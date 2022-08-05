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
    public partial class CarService : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.CarService; }
        }

        public CarService()
		{
		}	
        [JsonIgnore]
        public virtual Car Car { get; set; }

        [JsonIgnore]
        public virtual CarArrivalReasonType CarArrivalReasonType { get; set; }

        public virtual int? CarArrivalReasonTypeId { get; set; }

        public virtual int CarId { get; set; }

        public virtual string Conclusion { get; set; }

        public virtual string Defect { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public virtual int? Odometer { get; set; }

        public virtual DateTime? StartDate { get; set; }

        
		public CarService Clone()
        {
            var obj = new CarService
            {
                CarArrivalReasonTypeId = CarArrivalReasonTypeId,
                CarId = CarId,
                Conclusion = Conclusion,
                Defect = Defect,
                EndDate = EndDate,
                Odometer = Odometer,
                StartDate = StartDate,
            };

            if (IsNew())
            {
                if(Car != null && Car.IsNew())  
                {
                   obj.Car = Car;
                }
                if(CarArrivalReasonType != null && CarArrivalReasonType.IsNew())  
                {
                   obj.CarArrivalReasonType = CarArrivalReasonType;
                }
            }
            return obj;
        }
    }
}