using Rs.App.Core30.ClientRequest.Management.Domain;
using Rs.App.Core30.ClientRequest.Management.JsonRepositories;
using Rs.App.Core30.ClientRequest.Management.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core30.ClientRequest.Blazor.Data
{
    public class ClientService
    {
        private IRepository<Client> _clientRepo;
        public ClientService(IRepository<Client> clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public Task<List<Client>> GetClientsAsync()
        {
            var list = new List<Client>();
            list = _clientRepo.GetAll();
            return Task.FromResult(list);
        }

        public Task<Client> GetAsync(string id)
        {
            var client = _clientRepo.Get(Guid.Parse(id));
            return Task.FromResult(client);
        }

        public async Task AddAsync(Client client)
        {
            await Task.Run(() => _clientRepo.Add(client));
        }

        public async Task EditAsync(string id, Client client)
        {
            await Task.Run(() => _clientRepo.Update(Guid.Parse(id), client));
        }

        public async Task DeleteAsync(string id)
        {
            await Task.Run(() => _clientRepo.Delete(Guid.Parse(id)));
        }
    }
}
