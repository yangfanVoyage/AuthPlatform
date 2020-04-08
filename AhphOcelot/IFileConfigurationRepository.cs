using Ocelot.Configuration.File;
using Ocelot.Responses;
using System.Threading.Tasks;

namespace AhphOcelot
{
    public interface IFileConfigurationRepository
    {
        Task<Response<FileConfiguration>> Get();

        Task<Response> Set(FileConfiguration fileConfiguration);
    }
}
