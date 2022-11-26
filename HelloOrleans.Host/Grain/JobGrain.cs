using HelloOrleans.Host.Contract.Entity;
using HelloOrleans.Host.Contract.Grain;
using Orleans;
using Orleans.Providers;

namespace HelloOrleans.Host.Grain
{
    [StorageProvider(ProviderName = "hello-orleans")]
    public class JobGrain : Grain<Job>, IJobGrain
    {
        public async Task<Job> Create(Job job)
        {
            job.Identity = this.GetPrimaryKeyString();
            this.State = job;
            await this.WriteStateAsync();
            return this.State;
        }

        public Task<Job> Get()
        {
            return Task.FromResult(this.State);
        }

        public Task View(string contactId)
        {
            throw new NotImplementedException();
        }
    }
}
