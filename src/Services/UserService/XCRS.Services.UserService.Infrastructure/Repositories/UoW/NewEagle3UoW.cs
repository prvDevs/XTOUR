using XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories;
using XCRS.Services.UserService.Infrastructure.Contexts;

namespace XCRS.Services.UserService.Infrastructure.Repositories.UoW
{
    public class NewEagle3UoW : GenericUoW, INewEagle3UoW
    {
        public NewEagle3UoW(NewEagle3DbContext dbContext) : base(dbContext)
        {
        }

        public ITestRepository TestRepository()
        {
            return new TestRepository(_dbContext);
        }
    }
}
