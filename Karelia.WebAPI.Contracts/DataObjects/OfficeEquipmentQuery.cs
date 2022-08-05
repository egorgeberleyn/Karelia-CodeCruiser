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
    public partial class OfficeEquipmentQuery : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.OfficeEquipmentQuery; }
        }

        public OfficeEquipmentQuery()
		{
		}	
        public virtual string Description { get; set; }

        public virtual string InventoryNumber { get; set; }

        public virtual string OfficeEquipmentModel_Name { get; set; }

        public virtual int OfficeEquipmentModelId { get; set; }

        public virtual int OfficeId { get; set; }

        public virtual string OfiiceEmployee_Name { get; set; }

        public virtual DateTime? PlacementDate { get; set; }

        public virtual int? Quontity { get; set; }

        
		public OfficeEquipmentQuery Clone()
        {
            var obj = new OfficeEquipmentQuery
            {
                Description = Description,
                InventoryNumber = InventoryNumber,
                OfficeEquipmentModel_Name = OfficeEquipmentModel_Name,
                OfficeEquipmentModelId = OfficeEquipmentModelId,
                OfficeId = OfficeId,
                OfiiceEmployee_Name = OfiiceEmployee_Name,
                PlacementDate = PlacementDate,
                Quontity = Quontity,
            };

            return obj;
        }
    }
}