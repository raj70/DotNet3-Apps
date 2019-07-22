using Rs.App.Core30.ClientRequest.Management.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.ViewModels
{
    public class ClientRequests
    {
        public Client Client { get; set; }

        public List<Request> Requests { get; set; }

        public ClientRequests()
        {
            Client = new Client();
            Requests = new List<Request>();
        }
    }
}

