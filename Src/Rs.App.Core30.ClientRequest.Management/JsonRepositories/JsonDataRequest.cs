using Json.Net;
using Rs.App.Core30.ClientRequest.Management.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.JsonRepositories
{
    public class JsonDataRequest: IJsonDataFile<Request>
    {
        private Requests _requests;
        private string _fileName;

        public string FileName
        {
            get
            {
                return _fileName;
            }
        }

        public JsonDataRequest(Requests requests)
        {
            _requests = requests;
            _fileName = "Requests.json";
            if (!File.Exists(_fileName))
            {
                File.Create(_fileName);
            }
            Initialise();
        }

        public void Initialise()
        {
            if (File.Exists(this._fileName))
            {
                using (var stream = new StreamReader(_fileName))
                {
                    _requests = JsonNet.Deserialize<Requests>(stream);
                }
            }
        }

        public void Save()
        {
            var requestStringfy = JsonNet.Serialize(_requests);
            if (!string.IsNullOrWhiteSpace(requestStringfy))
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
