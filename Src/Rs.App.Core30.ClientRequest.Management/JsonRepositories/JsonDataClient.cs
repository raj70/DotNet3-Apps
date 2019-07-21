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
        private readonly object lock_object = new object();

        private Clients _clients;
        private string _fileName;

        public string FileName
        {
            get
            {
                return _fileName;
            }
        }
        public JsonDataClient()
        {
            if(_clients == null)
            {
                _clients = new Clients();
            }

            _fileName = "Clients.json";
        }

        public JsonDataClient(Clients clients) : this()
        {
            _clients = clients;
        }

        public void Initialise()
        {
            _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileName);
            if (File.Exists(_fileName))
            {
                using (var stream = new StreamReader(_fileName))
                {
                    var values = stream.ReadToEnd();
                    var clients = JsonConvert.DeserializeObject<Clients>(values);
                    clients.ForEach(x => {
                        if (!_clients.Contains(x))
                        {
                            _clients.Add(x);
                        }
                    });
                }
            }
        }

        public void Save()
        {
            lock (lock_object)
            {
                _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileName);
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
