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
    public partial class MethodicalToolkit : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.MethodicalToolkit; }
        }

        public MethodicalToolkit()
		{
		}	
        public virtual string Name { get; set; }

        
		public MethodicalToolkit Clone()
        {
            var obj = new MethodicalToolkit
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