using BusinessFramework.WebAPI.Contracts.Security;
using Karelia.WebAPI.Contracts.Security;

namespace Karelia.WebAPI.Security
{
    /// <summary>
    /// Class to process registered user
    /// </summary>
    public class PostRegistrationActionService : IPostRegistrationActionService
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public PostRegistrationActionService()
        {
        }

        /// <summary>
        /// Invoked after new user registered
        /// </summary>
        /// <param name="sysUser">User</param>
        public void OnUserRegistered(ISysUser sysUser)
        {
        }
    }
}
