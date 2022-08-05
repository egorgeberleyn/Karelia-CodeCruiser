using BusinessFramework.WebAPI.Contracts.Services;
using FutureTechnologies.DI.Contracts;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.Repositories;
using Karelia.WebAPI.Contracts.Security;


namespace Karelia.WebAPI.Security
{
    /// <inheritdoc />
    public sealed class SysUserService : ISysUserService
    {
        /// <inheritdoc />
        public SysUserService(IResolver resolver, ISysUserRepository sysUserRepository)
        {
            Resolver = resolver;
            SysUserRepository = sysUserRepository;
        }

        private IResolver Resolver { get; }
        private ISysUserRepository SysUserRepository { get; }

        /// <inheritdoc />
        public void Delete(int id)
        {
            try
            {
                //NOTE: Try permanently delete user in current scope
                SysUserRepository.Delete(id);
                SysUserRepository.Save();
            }
            catch
            {
                using (var scope = Resolver.BeginScope())
                {
                    //NOTE: Otherwise mark user as deleted
                    var repository = scope.Resolve<ISysUserRepository>();
                    scope.Resolve<ISysUserRepository>().Delete(id);
                    repository.Save();
                }
            }
        }
    }
}