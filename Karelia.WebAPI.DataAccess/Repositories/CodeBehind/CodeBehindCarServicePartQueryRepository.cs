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
    /// Repository for <see cref="CodeBehindCarServicePartQueryRepository"/> objects
    /// </summary>
    public abstract class CodeBehindCarServicePartQueryRepository : ClassicQueryRepository<CarServicePartQuery, int, CarServicePart, IApiDbContext>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected CodeBehindCarServicePartQueryRepository(IApiDbContext context) 
		    : base(context)
        {
        }


        /// <summary>
        /// Select <see cref="CarServicePartQuery"/> objects from <see cref="CarServicePart"/> objects
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
		protected override IQueryable<CarServicePartQuery> Set(IQueryable<CarServicePart> source)
        {
            return source.Select(o => new CarServicePartQuery
            {
					Id = o.Id,
					CarModelPart_Name = o.CarModelPart.Name,
					CarModelPart_Price = o.CarModelPart.Price,
					CarModelPartId = o.CarModelPartId,
					CarServiceId = o.CarServiceId,
					Quantity = o.Quantity,
  
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override CarServicePartQuery Create(CarServicePartQuery entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override CarServicePartQuery Update(CarServicePartQuery entity)
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
        public override void Delete(CarServicePartQuery entity)
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