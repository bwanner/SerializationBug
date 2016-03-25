using System.Threading.Tasks;
using Orleans;

namespace GrainLibraryProject
{
    public interface IGenericGrain<T> : IGrainWithGuidKey
    {
        Task<GenericWrapper<T>> Get();
    }

    /// <summary>
    /// Grain implementation class Grain1.
    /// </summary>
    public class GenericGrain<T> : Grain, IGenericGrain<T>
    {
        public Task<GenericWrapper<T>> Get()
        {
            return Task.FromResult(new GenericWrapper<T>());
        }
    }
}
