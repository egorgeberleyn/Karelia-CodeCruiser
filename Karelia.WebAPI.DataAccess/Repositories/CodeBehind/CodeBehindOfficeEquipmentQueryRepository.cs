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
    /// Repository for <see cref="CodeBehindOfficeEquipmentQueryRepository"/> objects
    /// </summary>
    public abstract class CodeBehindOfficeEquipmentQueryRepository : ClassicQueryRepository<OfficeEquipmentQuery, int, OfficeEquipment, IApiDbContext>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected CodeBehindOfficeEquipmentQueryRepository(IApiDbContext context) 
		    : base(context)
        {
        }


        /// <summary>
        /// Select <see cref="OfficeEquipmentQuery"/> objects from <see cref="OfficeEquipment"/> objects
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
		protected override IQueryable<OfficeEquipmentQuery> Set(IQueryable<OfficeEquipment> source)
        {
            return source.Select(o => new OfficeEquipmentQuery
            {
					Id = o.Id,
					Description = o.Description,
					InventoryNumber = o.InventoryNumber,
					OfficeEquipmentModel_Name = o.OfficeEquipmentModel.Name,
					OfficeEquipmentModelId = o.OfficeEquipmentModelId,
					OfficeId = o.OfficeId,
					OfiiceEmployee_Name = o.OfiiceEmployee.Name,
					PlacementDate = o.PlacementDate,
					Quontity = o.Quontity,
  
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override OfficeEquipmentQuery Create(OfficeEquipmentQuery entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override OfficeEquipmentQuery Update(OfficeEquipmentQuery entity)
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
        public override void Delete(OfficeEquipmentQuery entity)
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