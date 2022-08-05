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
    public partial class MainTaskQuery : ClassicApiEntity<int>
    {	
        public override IDomainObject DomainKey
        {
            get { return DomainObjects.MainTaskQuery; }
        }

        public MainTaskQuery()
		{
		}	
        public virtual string Comments { get; set; }

        public virtual DateTime? CreationDate { get; set; }

        public virtual string Employee_Name { get; set; }

        public virtual int EmployeeId { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public virtual bool IsCompleted { get; set; }

        public virtual string Name { get; set; }

        
		public MainTaskQuery Clone()
        {
            var obj = new MainTaskQuery
            {
                Comments = Comments,
                CreationDate = CreationDate,
                Employee_Name = Employee_Name,
                EmployeeId = EmployeeId,
                EndDate = EndDate,
                IsCompleted = IsCompleted,
                Name = Name,
            };

            return obj;
        }
    }
}