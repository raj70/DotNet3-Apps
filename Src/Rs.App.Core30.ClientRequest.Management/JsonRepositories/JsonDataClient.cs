using Json.Net;
using Newtonsoft.Json;
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
                    var values = stream.ReadToEnd();
                    var clients = JsonConvert.DeserializeObject<Clients>(values);
                    clients.ForEach(x => {
                        _clients.Add(x);
                    });
                }
            }
        }

        public void Save()
        {
            var clientStringfy = JsonNet.Serialize(_clients, new GuidConverter());
            if (string.IsNullOrWhiteSpace(clientStringfy))
            {
                return;
            }
            using (var stream = new StreamWriter(_fileName, false, Encoding.UTF8))
            {
                stream.Write(clientStringfy);
            }
        }
    }

    public class GuidConverter : IJsonConverter
    {
        public object Deserializer(string txt)
        {
            return Guid.Parse(txt);
        }

        public Type GetConvertingType()
        {
            return typeof(Guid);
        }

        public string Serializer(object obj)
        {
            if(obj == null)
            {
                return Guid.NewGuid().ToString();
            }

           return Guid.Parse(obj.ToString()).ToString();
        }
    }
}
