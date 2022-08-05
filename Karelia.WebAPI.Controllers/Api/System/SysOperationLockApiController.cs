using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessFramework.Contracts.DataObjects;
using Karelia.Contracts.DataObjects;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;
using BusinessFramework.WebAPI.Common.Controllers;
using BusinessFramework.WebAPI.Common.Request;
using BusinessFramework.WebAPI.Contracts.Security;
using BusinessFramework.WebAPI.Contracts.Services;
using BusinessFramework.WebAPI.Contracts.Validation;


namespace Karelia.WebAPI.Controllers.Api
{
    /// <summary>
    ///     Controls <see cref="SysOperationLock" /> objects
    /// </summary>
    public sealed class SysOperationLockApiController : AbstractApiController<SysOperationLock, SysOperationLockKey, ISysOperationLockRepository>
    {
        private static readonly object SyncRoot = new object();

	    /// <summary>
        /// Ctor
        /// </summary>
        public SysOperationLockApiController(ISysOperationLockRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, IWebApiActionService webApiActionService, ICommonSecurityService securityService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
        }

        private IWebApiActionService WebApiActionService { get; set; }


		/// <summary>
        /// Get <see cref="SysOperationLock"/> object by key
        /// </summary>
        [Authorization(DomainPermissions.OperationLock)]  
        public IHttpActionResult GetByKey(SysOperationLockKey key)
        {
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="SysOperationLock"/> objects
        /// </summary>
        /// <returns></returns>
        [Authorization(DomainPermissions.OperationLock)]  
        public IHttpActionResult GetAll()
        {
            return InternalGetAll();
        }

        /// <summary>
        /// Create <see cref="SysOperationLock"/> object
        /// </summary>
        [Authorization(DomainPermissions.OperationLock)]
        public HttpResponseMessage Post(SysOperationLock data)
        {
            WebApiActionService.SetCurrentAction(DomainActions.Object.SysOperationLock.Create);

            //TODO: Research static sync root, DI and IIS
            lock (SyncRoot)
            {
                Repository.Cleanup();
                var existingLock = Repository.GetByKey(data.GetKey());
                if (existingLock != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, existingLock);
                }

                data.AquiredTime = DateTime.Now;
                data.ExpirationTime = DateTime.Now.AddMinutes(2);
                Repository.Create(data);
                Repository.Save();
            }

            return GetObjectResult(ObjectOperationType.Create, data);
        }

        /// <summary>
        /// Update <see cref="SysOperationLock"/> object
        /// </summary>
        [Authorization(DomainPermissions.OperationLock)]
        public HttpResponseMessage Put(SysOperationLock data)
        {
            WebApiActionService.SetCurrentAction(DomainActions.Object.SysOperationLock.Update);

            //TODO: Research static sync root, DI and IIS
            lock (SyncRoot)
            {
                var existingLock = Repository.GetByKey(data.GetKey());
                if (existingLock == null)
                {
                    return Post(data);
                }

                data.ExpirationTime = DateTime.Now.AddMinutes(2);
                Repository.Update(data);
                Repository.Save();
            }

            return GetObjectResult(ObjectOperationType.Update, data);
        }
        
        /// <summary>
        /// Delete <see cref="SysOperationLock"/> object
        /// </summary>
		[Authorization(DomainPermissions.OperationLock)]
        public HttpResponseMessage Delete(SysOperationLockKey key)
        {
            WebApiActionService.SetCurrentAction(DomainActions.Object.SysOperationLock.Delete);

            //TODO: Research static sync root, DI and IIS
            lock (SyncRoot)
            {
                Repository.Delete(Repository.GetByKey(key));
                Repository.Save();
            }
            return GetObjectResult<SysOperationLock>(ObjectOperationType.Update, null);
        }

    }
}