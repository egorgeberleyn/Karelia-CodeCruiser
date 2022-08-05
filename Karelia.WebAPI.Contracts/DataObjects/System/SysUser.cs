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
    public partial class SysUser : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysUser; }
        }

        public SysUser()
		{
            CreateDate = DateTime.Now;
            FullAccess = false;
            IsAnonymous = false;
            IsDeactivated = false;
            IsEmailConfirmed = false;
            IsSystemUser = false;
		}	
        public virtual string AccountName { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime? DeactivationDate { get; set; }

        public virtual string Description { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string EMail { get; set; }

        public virtual string EmailToken { get; set; }

        public virtual bool FullAccess { get; set; }

        public virtual bool IsAnonymous { get; set; }

        public virtual bool IsDeactivated { get; set; }

        public virtual bool IsEmailConfirmed { get; set; }

        public virtual bool IsSystemUser { get; set; }

        public virtual byte[] PasswordHash { get; set; }

        [JsonIgnore]
        public virtual SysUsersDisplayView SysUsersDisplayView { get; set; }

        
		public SysUser Clone()
        {
            var obj = new SysUser
            {
                AccountName = AccountName,
                CreateDate = CreateDate,
                DeactivationDate = DeactivationDate,
                Description = Description,
                DisplayName = DisplayName,
                EMail = EMail,
                EmailToken = EmailToken,
                FullAccess = FullAccess,
                IsAnonymous = IsAnonymous,
                IsDeactivated = IsDeactivated,
                IsEmailConfirmed = IsEmailConfirmed,
                IsSystemUser = IsSystemUser,
                PasswordHash = PasswordHash,
            };

            if (IsNew())
            {
            }
            return obj;
        }
    }
}