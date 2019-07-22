using System;
using System.Collections.Generic;
using System.Text;
using Rs.App.Core30.ClientRequest.Management.Domain;
using Rs.App.Core30.ClientRequest.Management.Exceptions;
using Rs.App.Core30.ClientRequest.Management.Repositories;
using Rs.App.Core30.ClientRequest.Management.ViewModels;

namespace Rs.App.Core30.ClientRequest.Management.Services
{
    public class ClientRequestService : IClientRequestService
    {
        private IRepository<Client> _clientRepository;
        private IRequestRepository _rquestRepository;

        public ClientRequestService(IRepository<Client> clienRepository, IRequestRepository requestRepository)
        {
            _clientRepository = clienRepository;
            _rquestRepository = requestRepository;
        }
        public Client GetClient(Guid requestId)
        {
            var client = new Client();

            if (requestId == Guid.Empty)
            {
                throw new ArgumentException("Not a valid requestId, while requesting for client");
            }

            var request = _rquestRepository.Get(requestId);

            if(request == null)
            {
                throw new ItemNotFoundException("Request not found for given Id");
            }

            var clientId = request.ClientId;            

            client = _clientRepository.Get(clientId);

            return client;
        }

        public ClientRequests GetRequest(Guid clientId)
        {
            var clientRequests = new ClientRequests();

            if (clientId == Guid.Empty)
            {
                throw new ArgumentException("Not a valid Id, while requesting for client");
            }

            var client = _clientRepository.Get(clientId);

            if (client == null)
            {
                throw new ItemNotFoundException("Client not found for given Id");
            }

            var requests = _rquestRepository.GetAll(clientId);
            if(requests != null)
            {
                clientRequests.Requests = requests;
            }
            clientRequests.Client = client;

            
            return clientRequests;
        }
    }
}
