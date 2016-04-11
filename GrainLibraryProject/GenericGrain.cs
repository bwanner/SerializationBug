using System;
using System.Threading.Tasks;
using Orleans;

namespace GrainLibraryProject
{
    public interface IGenericGrain<T> : IGrainWithGuidKey
    {
        Task<GenericWrapper<T>> Get();

        Task<string> GetSiloIdentity();
    }

    /// <summary>
    /// Grain implementation class Grain1.
    /// </summary>
    public class GenericGrain<T> : Grain, IGenericGrain<T>
    {
        public override Task OnActivateAsync()
        {
            return base.OnActivateAsync();
        }

        public Task<GenericWrapper<T>> Get()
        {
            return Task.FromResult(new GenericWrapper<T>());
        }

        public Task<string> GetSiloIdentity()
        {
            return Task.FromResult(RuntimeIdentity);
        }
    }
}
