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
    public partial class CarServiceQuery : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.CarServiceQuery; }
        }

        public CarServiceQuery()
		{
		}	
        public virtual string CarArrivalReasonType_Name { get; set; }

        public virtual int? CarArrivalReasonTypeId { get; set; }

        public virtual int CarId { get; set; }

        public virtual string Conclusion { get; set; }

        public virtual string Defect { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public virtual int? Odometer { get; set; }

        public virtual DateTime? StartDate { get; set; }

        
		public CarServiceQuery Clone()
        {
            var obj = new CarServiceQuery
            {
                CarArrivalReasonType_Name = CarArrivalReasonType_Name,
                CarArrivalReasonTypeId = CarArrivalReasonTypeId,
                CarId = CarId,
                Conclusion = Conclusion,
                Defect = Defect,
                EndDate = EndDate,
                Odometer = Odometer,
                StartDate = StartDate,
            };

            return obj;
        }
    }
}