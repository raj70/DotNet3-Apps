using Json.Net;
using Rs.App.Core30.ClientRequest.Management.Domain;
using Rs.App.Core30.ClientRequest.Management.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.JsonRepositories
{
    public class ClientRepository : IRepository<Client>
    {
        private Clients _clients;     
     

        public ClientRepository()
        {
            _clients = new Clients();
        }

        public void Add(Client model)
        {
            if (!_clients.Contains(model))
            {
                _clients.Add(model);
            }
        }

        public void Delete(Guid id)
        {
            var client = _clients.Where(x => x.ClientId == id).FirstOrDefault();
            if(client != null)
            {
                _clients.Remove(client);
            }
        }

        public List<Client> GetAll()
        {
            return _clients;
        }
        
        public void Update(Guid id, Client model)
        {
            var client = _clients.Where(x => x.ClientId == id).FirstOrDefault();
            if(client != null)
            {
                client.LastName = model.LastName == "" ? client.LastName : model.LastName;
                client.MiddleName = model.MiddleName == "" ? client.MiddleName : model.MiddleName;
                client.Name = model.Name == "" ? client.Name : model.Name;
            }
        }
              

        private string Serialise(Client client)
        {
            return JsonNet.Serialize(client);
        }

        private Client Deserialise(string value)
        {
            return JsonNet.Deserialize<Client>(value);
        }
    }

    public class Clients : List<Client>
    {
        public Clients()
        {
            
        }
    }
}
