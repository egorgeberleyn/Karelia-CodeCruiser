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
    public partial class OfficeEquipment : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.OfficeEquipment; }
        }

        public OfficeEquipment()
		{
		}	
        public virtual string Description { get; set; }

        public virtual string InventoryNumber { get; set; }

        [JsonIgnore]
        public virtual Office Office { get; set; }

        public virtual int OfficeEmployeeId { get; set; }

        [JsonIgnore]
        public virtual OfficeEquipmentModel OfficeEquipmentModel { get; set; }

        public virtual int OfficeEquipmentModelId { get; set; }

        public virtual int OfficeId { get; set; }

        [JsonIgnore]
        public virtual OfiiceEmployee OfiiceEmployee { get; set; }

        public virtual DateTime? PlacementDate { get; set; }

        public virtual int? Quontity { get; set; }

        
		public OfficeEquipment Clone()
        {
            var obj = new OfficeEquipment
            {
                Description = Description,
                InventoryNumber = InventoryNumber,
                OfficeEmployeeId = OfficeEmployeeId,
                OfficeEquipmentModelId = OfficeEquipmentModelId,
                OfficeId = OfficeId,
                PlacementDate = PlacementDate,
                Quontity = Quontity,
            };

            if (IsNew())
            {
                if(Office != null && Office.IsNew())  
                {
                   obj.Office = Office;
                }
                if(OfficeEquipmentModel != null && OfficeEquipmentModel.IsNew())  
                {
                   obj.OfficeEquipmentModel = OfficeEquipmentModel;
                }
                if(OfiiceEmployee != null && OfiiceEmployee.IsNew())  
                {
                   obj.OfiiceEmployee = OfiiceEmployee;
                }
            }
            return obj;
        }
    }
}