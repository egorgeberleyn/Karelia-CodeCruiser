using System;
using System.Linq;
using BusinessFramework.WebAPI.Contracts.Exceptions;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;


namespace Karelia.WebAPI.DataAccess.Repositories
{
    /// <summary>
    /// Repository for <see cref="SysOperationLockRepository"/> objects
    /// </summary>
    public sealed class SysOperationLockRepository : CodeBehind.CodeBehindSysOperationLockRepository, ISysOperationLockRepository
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public SysOperationLockRepository(
            //--  custom dependencies
            ISecurityService securityService,
            //-- /custom dependencies
            IApiDbContext context) 
            : base(context)
        {
            SecurityService = securityService;
        }

        private ISecurityService SecurityService { get; }


        /// <inheritdoc />
        public override SysOperationLock Create(SysOperationLock obj)
        {
            obj.UserId = SecurityService.CurrentUser.Id;
            return base.Create(obj);
        }

        /// <inheritdoc />
        public override SysOperationLock Update(SysOperationLock obj)
        {
            obj.UserId = SecurityService.CurrentUser.Id;
            return base.Update(obj);
        }

        /// <inheritdoc />
        public override void Delete(SysOperationLock obj)
        {
            obj = Refresh(obj);
            if (obj.UserId != SecurityService.CurrentUser.Id)
            {
                throw new FailDomainException("Only lock owner can release lock.");
            }
            base.Delete(obj);
        }

        /// <summary>
        ///     Remove all operation locks
        /// </summary>
        public void Cleanup()
        {
             Set()
                .Where(ol => ol.ExpirationTime < DateTime.Now)
                .ToList()
                .ForEach(Delete);

            Context.SaveChanges();
       }
    }
}