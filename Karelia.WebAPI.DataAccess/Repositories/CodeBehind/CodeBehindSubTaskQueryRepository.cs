using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using BusinessFramework.WebAPI.Common.Data;
using BusinessFramework.WebAPI.Contracts.Files;
using Karelia.Contracts;
using Karelia.Contracts.Enums;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;


namespace Karelia.WebAPI.DataAccess.Repositories.CodeBehind
{
    /// <summary>
    /// Repository for <see cref="CodeBehindSubTaskQueryRepository"/> objects
    /// </summary>
    public abstract class CodeBehindSubTaskQueryRepository : ClassicQueryRepository<SubTaskQuery, int, SubTask, IApiDbContext>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected CodeBehindSubTaskQueryRepository(IApiDbContext context) 
		    : base(context)
        {
        }


        /// <summary>
        /// Select <see cref="SubTaskQuery"/> objects from <see cref="SubTask"/> objects
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
		protected override IQueryable<SubTaskQuery> Set(IQueryable<SubTask> source)
        {
            return source.Select(o => new SubTaskQuery
            {
					Id = o.Id,
					Description = o.Description,
					MainTask_Employee_Name = o.MainTask.Employee.Name,
					Name = o.Name,
					Sequence = o.Sequence,
					TaskId = o.TaskId,
  
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override SubTaskQuery Create(SubTaskQuery entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override SubTaskQuery Update(SubTaskQuery entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Delete(int key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Delete(SubTaskQuery entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Save()
        {
            Context.SaveChanges();
        }
    }
}