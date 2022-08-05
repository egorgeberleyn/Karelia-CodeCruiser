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
    public partial class MethodicalToolkitFile : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.MethodicalToolkitFile; }
        }

        public MethodicalToolkitFile()
		{
		}	
        public virtual string Description { get; set; }

        [JsonIgnore]
        public virtual MethodicalToolkit MethodicalToolkit { get; set; }

        public virtual int MethodicalToolkitId { get; set; }

        public virtual string Name { get; set; }

        
		public MethodicalToolkitFile Clone()
        {
            var obj = new MethodicalToolkitFile
            {
                Description = Description,
                MethodicalToolkitId = MethodicalToolkitId,
                Name = Name,
            };

            if (IsNew())
            {
                if(MethodicalToolkit != null && MethodicalToolkit.IsNew())  
                {
                   obj.MethodicalToolkit = MethodicalToolkit;
                }
            }
            return obj;
        }
    }
}