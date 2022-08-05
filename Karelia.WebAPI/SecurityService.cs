using BusinessFramework.Contracts.Security;
using BusinessFramework.WebAPI.Common.Request;
using BusinessFramework.WebAPI.Security;
using Karelia.Contracts;
using Karelia.WebAPI.Contracts;

namespace Karelia.WebAPI
{
    /// <summary>
    ///     Security service
    /// </summary>
    public sealed partial class SecurityService : BaseSecurityService<DomainPermissions>, ISecurityService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public SecurityService(IRequestStorage requestStorage)
            : base(requestStorage)
        {
        }

        /// <summary>
        ///     Get public security context for clients
        /// </summary>
        public PublicSecurityContext<PublicDomainPermissions> GetPublicContext()
        {
            var permissions = GetPublicPermissions();

            var context = new PublicSecurityContext<PublicDomainPermissions>
            {
                Id = CurrentUser.Id,
                DisplayName = CurrentUser.DisplayName,
                EMail = CurrentUser.EMail,
                Description = CurrentUser.Description,
                AllowedPublicPermissions = permissions
            };

            return context;
        }

        /// <summary>
        ///     Check authorization by permission
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        protected override bool MakeAuthorize(DomainPermissions permission)
        {
            return Principal.Authorize((int)permission);
        }
    }
}