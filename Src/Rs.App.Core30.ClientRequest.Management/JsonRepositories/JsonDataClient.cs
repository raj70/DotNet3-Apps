using Json.Net;
using Rs.App.Core30.ClientRequest.Management.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.JsonRepositories
{
    public class JsonDataClient: IJsonDataFile<Client>
    {
        private Clients _clients;
        private string _fileName;

        public string FileName
        {
            get
            {
                return _fileName;
            }
        }

        public JsonDataClient(Clients clients)
        {
            _clients = clients;
            _fileName = "Clients.json";
        }

        public void Initialise()
        {
            if (File.Exists(this._fileName))
            {
                using (var stream = new StreamReader(_fileName))
                {
                    _clients = JsonNet.Deserialize<Clients>(stream);
                }
            }
            else
            {
                _clients.Add(new Client() { LastName ="Shrestha", MiddleName="", Name="Rajen" });
                _clients.Add(new Client() { LastName = "Shrestha", MiddleName = "", Name = "Zuzana" });
            }
        }

        public void Save()
        {
            var clientStringfy = JsonNet.Serialize(_clients);
            if (!string.IsNullOrWhiteSpace(clientStringfy))
            {
                return;
            }
            using (var stream = new StreamWriter(_fileName, false, Encoding.UTF8))
            {
                stream.Write(clientStringfy);
            }
        }
    }
}
