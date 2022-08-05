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
    public partial class SysSetting : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysSetting; }
        }

        public SysSetting()
		{
		}	
        public virtual int SettingPropertyId { get; set; }

        public virtual string StringValue { get; set; }

        [JsonIgnore]
        public virtual SysSettingProperty SysSettingProperty { get; set; }

        [JsonIgnore]
        public virtual SysUser SysUser { get; set; }

        public virtual int? UserId { get; set; }

        
		public SysSetting Clone()
        {
            var obj = new SysSetting
            {
                SettingPropertyId = SettingPropertyId,
                StringValue = StringValue,
                UserId = UserId,
            };

            if (IsNew())
            {
                if(SysSettingProperty != null && SysSettingProperty.IsNew())  
                {
                   obj.SysSettingProperty = SysSettingProperty;
                }
                if(SysUser != null && SysUser.IsNew())  
                {
                   obj.SysUser = SysUser;
                }
            }
            return obj;
        }
    }
}