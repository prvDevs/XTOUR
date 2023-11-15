using XCRS.Services.Core.Domain.Settings;

namespace XCRS.Services.TargetService.Domain.Settings
{
    public interface ITargetDbSettings : IMongoDbSettings { 
    }
    public class TargetsDbSettings : ITargetDbSettings
    {
        public required string DatabaseName { get; set; }
        public required string ConnectionString { get; set; }
    }
}
