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
    public partial class MainTask : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.MainTask; }
        }

        public MainTask()
		{
		}	
        public virtual string Comments { get; set; }

        public virtual DateTime? CreationDate { get; set; }

        [JsonIgnore]
        public virtual OfiiceEmployee Employee { get; set; }

        public virtual int EmployeeId { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public virtual bool IsCompleted { get; set; }

        public virtual string Name { get; set; }

        
		public MainTask Clone()
        {
            var obj = new MainTask
            {
                Comments = Comments,
                CreationDate = CreationDate,
                EmployeeId = EmployeeId,
                EndDate = EndDate,
                IsCompleted = IsCompleted,
                Name = Name,
            };

            if (IsNew())
            {
                if(Employee != null && Employee.IsNew())  
                {
                   obj.Employee = Employee;
                }
            }
            return obj;
        }
    }
}