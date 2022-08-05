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
    /// Repository for <see cref="CodeBehindCarServiceQueryRepository"/> objects
    /// </summary>
    public abstract class CodeBehindCarServiceQueryRepository : ClassicQueryRepository<CarServiceQuery, int, CarService, IApiDbContext>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected CodeBehindCarServiceQueryRepository(IApiDbContext context) 
		    : base(context)
        {
        }


        /// <summary>
        /// Select <see cref="CarServiceQuery"/> objects from <see cref="CarService"/> objects
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
		protected override IQueryable<CarServiceQuery> Set(IQueryable<CarService> source)
        {
            return source.Select(o => new CarServiceQuery
            {
					Id = o.Id,
					CarArrivalReasonType_Name = o.CarArrivalReasonType == null ? default(string) : o.CarArrivalReasonType.Name,
					CarArrivalReasonTypeId = o.CarArrivalReasonTypeId,
					CarId = o.CarId,
					Conclusion = o.Conclusion,
					Defect = o.Defect,
					EndDate = o.EndDate,
					Odometer = o.Odometer,
					StartDate = o.StartDate,
  
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override CarServiceQuery Create(CarServiceQuery entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override CarServiceQuery Update(CarServiceQuery entity)
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
        public override void Delete(CarServiceQuery entity)
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