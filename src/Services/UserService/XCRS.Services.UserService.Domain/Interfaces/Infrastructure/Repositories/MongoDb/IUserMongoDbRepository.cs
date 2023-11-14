using XCRS.Services.UserService.Core.Entities;

namespace XCRS.Services.UserService.Domain.Interfaces.Infrastructure.Repositories.MongoDb
{
    public interface IUserMongoDbRepository : IGenericMongoDbRepository<User>
    {
    }
}
