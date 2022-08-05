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
    public partial class SysSettingProperty : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysSettingProperty; }
        }

        public SysSettingProperty()
		{
            IsOverridable = true;
		}	
        public virtual string DefaultType { get; set; }

        public virtual string Description { get; set; }

        public virtual string GroupName { get; set; }

        public virtual bool IsManaged { get; set; }

        public virtual bool IsOverridable { get; set; }

        public virtual string Name { get; set; }

        public virtual string UIEditorType { get; set; }

        
		public SysSettingProperty Clone()
        {
            var obj = new SysSettingProperty
            {
                DefaultType = DefaultType,
                Description = Description,
                GroupName = GroupName,
                IsManaged = IsManaged,
                IsOverridable = IsOverridable,
                Name = Name,
                UIEditorType = UIEditorType,
            };

            if (IsNew())
            {
            }
            return obj;
        }
    }
}