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
    public partial class SubTaskQuery : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SubTaskQuery; }
        }

        public SubTaskQuery()
		{
		}	
        public virtual string Description { get; set; }

        public virtual string MainTask_Employee_Name { get; set; }

        public virtual string Name { get; set; }

        public virtual int? Sequence { get; set; }

        public virtual int TaskId { get; set; }

        
		public SubTaskQuery Clone()
        {
            var obj = new SubTaskQuery
            {
                Description = Description,
                MainTask_Employee_Name = MainTask_Employee_Name,
                Name = Name,
                Sequence = Sequence,
                TaskId = TaskId,
            };

            return obj;
        }
    }
}