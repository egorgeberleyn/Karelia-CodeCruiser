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
    public partial class SysOperationLock : AbstractApiEntity<SysOperationLockKey>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysOperationLock; }
        }

        public SysOperationLock()
		{
		}	
        public virtual string OperationName { get; set; }

        public virtual string OperationContext { get; set; }

        public virtual DateTime AquiredTime { get; set; }

        public virtual DateTime ExpirationTime { get; set; }

        public virtual string MachineName { get; set; }

        public virtual int? ProcessId { get; set; }

        [JsonIgnore]
        public virtual SysUser SysUser { get; set; }

        [JsonIgnore]
        public virtual int UserId { get; set; }

        public override SysOperationLockKey GetKey()
        {
            return new SysOperationLockKey(OperationName, OperationContext);
            
        }
        
		public bool IsNew()
        {
		    return Equals(OperationName, default(string)) && Equals(OperationContext, default(string));
        }
        
		public SysOperationLock Clone()
        {
            var obj = new SysOperationLock
            {
                AquiredTime = AquiredTime,
                ExpirationTime = ExpirationTime,
                MachineName = MachineName,
                ProcessId = ProcessId,
                UserId = UserId,
            };

            return obj;
        }
    }
}