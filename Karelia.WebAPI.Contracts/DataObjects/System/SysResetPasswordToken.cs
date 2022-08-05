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
    public partial class SysResetPasswordToken : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysResetPasswordToken; }
        }

        public SysResetPasswordToken()
		{
            IsExecuted = false;
		}	
        public virtual bool IsExecuted { get; set; }

        [JsonIgnore]
        public virtual SysUser SysUser { get; set; }

        public virtual string Token { get; set; }

        public virtual int UserId { get; set; }

        public virtual DateTimeOffset ValidFrom { get; set; }

        
		public SysResetPasswordToken Clone()
        {
            var obj = new SysResetPasswordToken
            {
                IsExecuted = IsExecuted,
                Token = Token,
                UserId = UserId,
                ValidFrom = ValidFrom,
            };

            if (IsNew())
            {
                if(SysUser != null && SysUser.IsNew())  
                {
                   obj.SysUser = SysUser;
                }
            }
            return obj;
        }
    }
}