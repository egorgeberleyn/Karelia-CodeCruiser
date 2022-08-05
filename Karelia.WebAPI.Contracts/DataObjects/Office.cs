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
    public partial class Office : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.Office; }
        }

        public Office()
		{
		}	
        public virtual string Adress { get; set; }

        
		public Office Clone()
        {
            var obj = new Office
            {
                Adress = Adress,
            };

            if (IsNew())
            {
            }
            return obj;
        }
    }
}