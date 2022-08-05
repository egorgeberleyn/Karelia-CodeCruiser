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
    public partial class OfficeEquipmentModel : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.OfficeEquipmentModel; }
        }

        public OfficeEquipmentModel()
		{
		}	
        public virtual string Name { get; set; }

        
		public OfficeEquipmentModel Clone()
        {
            var obj = new OfficeEquipmentModel
            {
                Name = Name,
            };

            if (IsNew())
            {
            }
            return obj;
        }
    }
}