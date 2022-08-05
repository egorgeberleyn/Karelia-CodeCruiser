using System;
using System.Collections.Generic;
using BusinessFramework.Contracts;
using BusinessFramework.Contracts.DataObjects;
using BusinessFramework.WebAPI.Contracts.DataObjects;
using BusinessFramework.WebAPI.Contracts.Metadata;
using Karelia.Contracts.DataObjects;
using Karelia.Contracts.Enums;
using Newtonsoft.Json;

namespace Karelia.WebAPI.Contracts.DataObjects
{    
    public partial class SysOperation : ClassicApiEntity<long>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SysOperation; }
        }

        public SysOperation()
		{
		}	
        [JsonIgnore]
        public virtual SysObject Action { get; set; }

        public virtual int ActionId { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual string OperationDetails { get; set; }

        [JsonIgnore]
        public virtual SysOperationResult OperationResult { get; set; }

        public virtual byte OperationResultId { get; set; }

        public virtual string Request { get; set; }

        public virtual string RequestContent { get; set; }

        [JsonIgnore]
        public virtual SysUser SysUser { get; set; }

        public virtual int UserID { get; set; }

        
		public SysOperation Clone()
        {
            var obj = new SysOperation
            {
                ActionId = ActionId,
                Date = Date,
                OperationDetails = OperationDetails,
                OperationResultId = OperationResultId,
                Request = Request,
                RequestContent = RequestContent,
                UserID = UserID,
            };

            if (IsNew())
            {
                if(Action != null && Action.IsNew())  
                {
                   obj.Action = Action;
                }
                if(OperationResult != null && OperationResult.IsNew())  
                {
                   obj.OperationResult = OperationResult;
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