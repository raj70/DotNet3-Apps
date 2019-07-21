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
        private IJsonDataFile<Client> _jsonDataFile;

        public ClientRepository()
        {
            _clients = new Clients();
            _jsonDataFile = new JsonDataClient(_clients);
        }

        public void Add(Client model)
        {
            if (!_clients.Contains(model))
            {
                _clients.Add(model);
                _jsonDataFile.Save();
            }
        }

        public void Delete(Guid id)
        {
            var client = _clients.Where(x => x.ClientId == id).FirstOrDefault();
            if(client != null)
            {
                _clients.Remove(client);
                _jsonDataFile.Save();
            }
        }

        public Client Get(Guid id)
        {
            var client = _clients.Where(x => x.ClientId == id).FirstOrDefault();
            return client;
        }

        public List<Client> GetAll()
        {
            _jsonDataFile.Initialise();
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
                _jsonDataFile.Save();
            }
        }
            
    }

    public class Clients : List<Client>
    {
        public Clients()
        {
            
        }
    }
}
