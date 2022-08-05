using System;
using System.Collections.Generic;
using Karelia.WebAPI.Contracts.DataObjects;
using BusinessFramework.WebAPI.Contracts.Data;

namespace Karelia.WebAPI.Contracts.Repositories
{
    public interface ISysResetPasswordTokenRepository: IClassicEntityRepository<SysResetPasswordToken, int>
    {
        SysResetPasswordToken Resolve(string token);
    }
}
