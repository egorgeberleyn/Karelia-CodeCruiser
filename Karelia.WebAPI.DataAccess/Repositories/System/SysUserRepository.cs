using System;
using System.Collections.Generic;
using System.Linq;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;
using BusinessFramework.WebAPI.Contracts.Security;
using BusinessFramework.WebAPI.Contracts.Security.Hash;
using BusinessFramework.WebAPI.Contracts.Services;
using ColoredConsole;

namespace Karelia.WebAPI.DataAccess.Repositories
{
    /// <summary>
    /// Repository for <see cref="SysUserRepository"/> objects
    /// </summary>
    public sealed class SysUserRepository : CodeBehind.CodeBehindSysUserRepository, ISysUserRepository
    {
        private const int PublicRoleId = -1;

        /// <summary>
        /// Ctor
        /// </summary>
        public SysUserRepository(
            //--  custom dependencies
            IWebApiSettingsService webApiSettingsService, 
            ISysUserRoleRepository sysUserRoleRepository, 
            ISysRoleRepository sysRoleRepository,
            IPasswordHashProvider passwordHashProvider, 
            IEmailConfirmationService emailConfirmationService,
            //-- /custom dependencies
            IApiDbContext context) 
		    : base(context)
        {
            SysUserRoleRepository = sysUserRoleRepository;
            SysRoleRepository = sysRoleRepository;
            WebApiSettingsService = webApiSettingsService;
            HashProvider = passwordHashProvider;
            EmailConfirmationService = emailConfirmationService;
        }

        private IWebApiSettingsService WebApiSettingsService { get; }
        private IPasswordHashProvider HashProvider { get; }
        private IEmailConfirmationService EmailConfirmationService { get; }
        private ISysUserRoleRepository SysUserRoleRepository { get; }
        private ISysRoleRepository SysRoleRepository { get; }

        /// <inheritdoc />
        public override SysUser Create(SysUser obj)
        {
            obj.PasswordHash = HashProvider.GetPasswordHash(obj.Password);
            obj.EmailToken = Guid.NewGuid().ToString();
            if (obj.CreateDate == default(DateTime))
            {
                obj.CreateDate = DateTime.Now;
            }
            var result = base.Create(obj);

            //NOTE: Create user owned role and put user to it
            var userOwnedRole = new SysRole
            {
                Name = result.AccountName,
                IsOwnByUser = true,
                OwnerUser = result
            };
            userOwnedRole = SysRoleRepository.Create(userOwnedRole);
            SysUserRoleRepository.Create(new SysUserRole {SysUser = result, SysRole = userOwnedRole});

            //NOTE: Add user to Public role
            SysUserRoleRepository.Create(new SysUserRole {SysUser = result, RoleId = PublicRoleId});

            if (WebApiSettingsService.AllowRegistration && WebApiSettingsService.UseEmailVerification)
            {
                try
                {
                    EmailConfirmationService.SendConfirmationMail(obj);
                }
                catch (Exception exception)
                {
                    ColorConsole.WriteLine($"Filed to send confirmation email: {exception.Message}".DarkRed());
                }
            }
            return result;
        }

        /// <inheritdoc />
        public override SysUser Update(SysUser obj)
        {
            var dbObj = GetByKey(obj.GetKey());

            obj.PasswordHash = string.IsNullOrEmpty(obj.Password) ? dbObj.PasswordHash : HashProvider.GetPasswordHash(obj.Password);

            if (obj.IsDeactivated != dbObj.IsDeactivated)
            {
                obj.DeactivationDate = obj.IsDeactivated ? DateTime.Now : (DateTime?) null;
            }
            return base.Update(obj);
        }

        /// <summary>
        /// Get user by email
        /// </summary>
        public SysUser GetByAccountNameOrEmail(string identifier)
        {
            return Context.GetSet<SysUser>()
                .FirstOrDefault(u => string.Compare(u.EMail, identifier, StringComparison.OrdinalIgnoreCase) == 0
                                     || string.Compare(u.AccountName, identifier, StringComparison.OrdinalIgnoreCase) == 0);
        }

        /// <inheritdoc />
        public IList<int> GetUserPermissions(int userId)
        {
            return SysUserRoleRepository.Set().Where(o => o.UserId == userId && !o.SysUser.IsDeactivated)
                .SelectMany(o => o.SysRole.SysRolePermissions).Select(p => p.PermissionId).Distinct()
                .ToList();
        }

        /// <inheritdoc />
        public override void Delete(SysUser obj)
        {
            base.Delete(obj);
            DeleteDependencies(obj?.Id ?? -1);
        }

        private void DeleteDependencies(int id)
        {
            var userRoleLinks = SysUserRoleRepository.Set()
                .Where(o => o.UserId == id).ToList();

            foreach (var userRoleLink in userRoleLinks)
            {
                SysUserRoleRepository.Delete(userRoleLink);
            }

            var ownerRoleLinks = SysRoleRepository.Set()
                .Where(o => o.OwnerUserID == id).ToList();

            foreach (var ownerRoleLink in ownerRoleLinks)
            {
                SysRoleRepository.Delete(ownerRoleLink);
            }
        }
    }
}