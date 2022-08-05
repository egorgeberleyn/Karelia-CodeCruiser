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
    public partial class SysObject : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysObject; }
        }

        public SysObject()
		{
		}	
        public virtual byte ClassId { get; set; }

        public virtual string CodeName { get; set; }

        public virtual int? DbFieldId { get; set; }

        public virtual int? DbObjectId { get; set; }

        public virtual string Description { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual Guid Guid { get; set; }

        public virtual int ParentId { get; set; }

        [JsonIgnore]
        public virtual SysObjectClass SysObjectClass { get; set; }

        
		public SysObject Clone()
        {
            var obj = new SysObject
            {
                ClassId = ClassId,
                CodeName = CodeName,
                DbFieldId = DbFieldId,
                DbObjectId = DbObjectId,
                Description = Description,
                DisplayName = DisplayName,
                Guid = Guid,
                ParentId = ParentId,
            };

            if (IsNew())
            {
                if(SysObjectClass != null && SysObjectClass.IsNew())  
                {
                   obj.SysObjectClass = SysObjectClass;
                }
            }
            return obj;
        }
    }
}