using BusinessFramework.WebAPI.Common.Data;
using BusinessFramework.WebAPI.Contracts.Data;
using BusinessFramework.WebAPI.Contracts.Files;
using BusinessFramework.WebAPI.Contracts.Security;
using Karelia.WebAPI.Contracts;

namespace Karelia.WebAPI.DataAccess.Repositories
{
    /// <summary>
    ///     Sys file repository. It can be used with different contexts
    /// </summary>
    public sealed class FileLinkRepository : ClassicEntityRepository<FileLink, int, IApiDbContext>, IFileLinkRepository
    {
        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="securityService"></param>
        public FileLinkRepository(IApiDbContext context, ICommonSecurityService securityService)
            : base(context)
        {
            SecurityService = securityService;
        }

        private ICommonSecurityService SecurityService { get; }

        /// <inheritdoc />
        public override FileLink Create(FileLink obj)
        {
            if (SecurityService.CurrentUser != null && obj.SysUserId == 0)
            {
                obj.SysUserId = SecurityService.CurrentUser.Id;
            }
            return base.Create(obj);
        }
    }
}