using Json.Net;
using Newtonsoft.Json;
using Rs.App.Core30.ClientRequest.Management.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.JsonRepositories
{
    public class JsonDataRequest: IJsonDataFile<Request>
    {
        private readonly object lock_object = new object();

        private Requests _requests;
        private string _fileName;

        public JsonDataRequest()
        {
            if(_requests == null)
            {
                _requests = new Requests();
            }

            _fileName = "Requests.json";
        }

        public JsonDataRequest(Requests requests): this()
        {
            _requests = requests;
            Initialise();
        }

        public string FileName
        {
            get
            {
                return _fileName;
            }
        }

        public void Initialise()
        {
            _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileName);
            if (File.Exists(this._fileName))
            {
                using (var stream = new StreamReader(_fileName))
                {
                    var values = stream.ReadToEnd();
                    var requests = JsonConvert.DeserializeObject<Requests>(values);
                    requests.ForEach(x => {
                        if (!_requests.Contains(x))
                        {
                            _requests.Add(x);
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
                var requestStringfy = JsonNet.Serialize(_requests, new GuidConverter());
                if (string.IsNullOrWhiteSpace(requestStringfy))
                {
                    return;
                }
                using (var stream = new StreamWriter(_fileName, false, Encoding.UTF8))
                {
                    stream.Write(requestStringfy);
                }
            }
        }
    }
}
