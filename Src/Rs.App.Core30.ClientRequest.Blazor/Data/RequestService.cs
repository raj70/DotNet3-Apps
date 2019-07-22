using Rs.App.Core30.ClientRequest.Management.Domain;
using Rs.App.Core30.ClientRequest.Management.Repositories;
using Rs.App.Core30.ClientRequest.Management.Services;
using Rs.App.Core30.ClientRequest.Management.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core30.ClientRequest.Blazor.Data
{
    public class RequestService
    {
        private IRequestRepository _repository;
        private IClientRequestService _clientRequestService;

        public RequestService(IRequestRepository repository, IClientRequestService clientRequestService)
        {
            _repository = repository;
            _clientRequestService = clientRequestService;
        }

        public async Task AddRequestAsync(Request request)
        {
            await Task.Run(() => _repository.Add(request));
        }

        public Task<ClientRequests>  GetClientRequestsAsync(Guid clientId, bool includeRequest = true)
        {
            var clientRequests = _clientRequestService.GetRequest(clientId);

            if (!includeRequest)
            {
                clientRequests.Requests = new List<Request>();
            }
           
            return Task.FromResult(clientRequests);
        }
    }
}
