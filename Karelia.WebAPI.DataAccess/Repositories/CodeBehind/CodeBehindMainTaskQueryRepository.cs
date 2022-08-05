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
    /// Repository for <see cref="CodeBehindMainTaskQueryRepository"/> objects
    /// </summary>
    public abstract class CodeBehindMainTaskQueryRepository : ClassicQueryRepository<MainTaskQuery, int, MainTask, IApiDbContext>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected CodeBehindMainTaskQueryRepository(IApiDbContext context) 
		    : base(context)
        {
        }


        /// <summary>
        /// Select <see cref="MainTaskQuery"/> objects from <see cref="MainTask"/> objects
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
		protected override IQueryable<MainTaskQuery> Set(IQueryable<MainTask> source)
        {
            return source.Select(o => new MainTaskQuery
            {
					Id = o.Id,
					Comments = o.Comments,
					CreationDate = o.CreationDate,
					Employee_Name = o.Employee.Name,
					EmployeeId = o.EmployeeId,
					EndDate = o.EndDate,
					IsCompleted = o.IsCompleted,
					Name = o.Name,
  
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override MainTaskQuery Create(MainTaskQuery entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override MainTaskQuery Update(MainTaskQuery entity)
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
        public override void Delete(MainTaskQuery entity)
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