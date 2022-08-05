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
    public partial class SubTask : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.SubTask; }
        }

        public SubTask()
		{
		}	
        public virtual string Description { get; set; }

        [JsonIgnore]
        public virtual MainTask MainTask { get; set; }

        public virtual string Name { get; set; }

        public virtual int? Sequence { get; set; }

        public virtual int TaskId { get; set; }

        
		public SubTask Clone()
        {
            var obj = new SubTask
            {
                Description = Description,
                Name = Name,
                Sequence = Sequence,
                TaskId = TaskId,
            };

            if (IsNew())
            {
                if(MainTask != null && MainTask.IsNew())  
                {
                   obj.MainTask = MainTask;
                }
            }
            return obj;
        }
    }
}