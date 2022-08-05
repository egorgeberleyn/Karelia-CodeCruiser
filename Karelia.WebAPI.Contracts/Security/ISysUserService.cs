namespace Karelia.WebAPI.Contracts.Security
{
    public interface ISysUserService
    {
        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="userId"></param>
        void Delete(int userId);

    }
}