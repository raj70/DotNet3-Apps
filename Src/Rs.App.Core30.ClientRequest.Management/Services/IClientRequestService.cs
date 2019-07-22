using Rs.App.Core30.ClientRequest.Management.Domain;
using Rs.App.Core30.ClientRequest.Management.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.Services
{
    public interface IClientRequestService
    {
        Client GetClient(Guid requestId);
        ClientRequests GetRequest(Guid clientId);
    }
}
