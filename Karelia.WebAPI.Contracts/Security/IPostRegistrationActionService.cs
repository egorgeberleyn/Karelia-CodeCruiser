
using BusinessFramework.WebAPI.Contracts.Security;

namespace Karelia.WebAPI.Contracts.Security
{
    /// <summary>
    /// Class to process registered user
    /// </summary>
    public interface IPostRegistrationActionService
    {
        /// <summary>
        /// Invoked after new user registered
        /// </summary>
        /// <param name="sysUser">User</param>
        void OnUserRegistered(ISysUser sysUser);
    }
}