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
    public partial class SysRefreshToken : AbstractApiEntity<SysRefreshTokenKey>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysRefreshToken; }
        }

        public SysRefreshToken()
		{
		}	
        public virtual int UserId { get; set; }

        public virtual string ClientId { get; set; }

        public virtual DateTimeOffset ExpiresUtc { get; set; }

        [JsonIgnore]
        public virtual SysUser SysUser { get; set; }

        public virtual string Token { get; set; }

        public override SysRefreshTokenKey GetKey()
        {
            return new SysRefreshTokenKey(UserId, ClientId);
            
        }
        
		public bool IsNew()
        {
		    return Equals(UserId, default(int)) && Equals(ClientId, default(string));
        }
        
		public SysRefreshToken Clone()
        {
            var obj = new SysRefreshToken
            {
                ExpiresUtc = ExpiresUtc,
                Token = Token,
            };

            return obj;
        }
    }
}