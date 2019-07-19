using Json.Net;
using Rs.App.Core30.ClientRequest.Management.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.JsonRepositories
{
    public class RequestRepository : IJsonDataFile<Request>
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

        public Requests Requests
        {
            get
            {
                return _requests;
            }
        }

        public RequestRepository()
        {
            _requests = new Requests();
            _fileName = "Requests.json";
            Initialise();
        }

        public void Add(Request model)
        {
            if (!_requests.Contains(model))
            {
                _requests.Add(model);
            }
        }

        public void Delete(Guid id)
        {
            var client = _requests.Where(x => x.RequestId == id).FirstOrDefault();
            if(client != null)
            {
                _requests.Remove(client);
            }
        }

        public List<Request> GetAll()
        {
            return _requests;
        }
        
        public void Update(Guid id, Request model)
        {
            var request = _requests.Where(x => x.RequestId == id).FirstOrDefault();
            if(request != null)
            {
                request.Name = model.Name == "" ? request.Name : model.Name;
                request.Priority = model.Priority;
                request.Description = model.Description == "" ? request.Description : model.Description;
                request.Comments = model.Comments == "" ? request.Comments : model.Comments;
            }
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

        private string Serialise(Request client)
        {
            return JsonNet.Serialize(client);
        }

        private Request Deserialise(string value)
        {
            return JsonNet.Deserialize<Request>(value);
        }
    }

    public class Requests : List<Request>
    {
        public Requests()
        {
            
        }
    }
}
