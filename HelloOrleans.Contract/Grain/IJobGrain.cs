using HelloOrleans.Host.Contract.Entity;
using Orleans;

namespace HelloOrleans.Host.Contract.Grain
{
    public interface IJobGrain : IGrainWithStringKey
    {
        Task<Job> Create(Job job);
        Task<Job> Get();
        Task View(string contactId);
    }
}
