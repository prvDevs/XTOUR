using Microsoft.EntityFrameworkCore;
using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;
using XCRS.Services.UserService.Infrastructure.Contexts;

namespace XCRS.Services.UserService.Infrastructure.Repositories.UoW
{
    public class ModeWeb3UoW : GenericUoW, IModeWeb3UoW
    {
        public ModeWeb3UoW(ModeWeb3DbContext dbContext) : base(dbContext)
        {
        }
    }
}
