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
    public class RequestRepository : IRequestRepository
    {
        private Requests _requests;
        private IJsonDataFile<Request> _jsonDataFile;       

        public RequestRepository()
        {
            _requests = new Requests();
            _jsonDataFile = new JsonDataRequest(_requests);
            _jsonDataFile.Initialise();
        }

        public void Add(Request model)
        {
            if (!_requests.Contains(model))
            {
                _requests.Add(model);
                _jsonDataFile.Save();
            }
        }

        public void Delete(Guid id)
        {
            var client = _requests.Where(x => x.RequestId == id).FirstOrDefault();
            if (client != null)
            {
                _requests.Remove(client);
                _jsonDataFile.Save();
            }
        }

        public Request Get(Guid id)
        {
            return _requests.Where(x => x.RequestId == id).FirstOrDefault();
        }

        public List<Request> GetAll(Guid clientId)
        {
            var request = _requests.Where(x => x.ClientId == clientId);
            if(!request.Any())
            {
                request = new List<Request>();
            }
            return request.ToList();
        }

        public List<Request> GetAll()
        {
            _jsonDataFile.Initialise();
            return _requests;
        }
        
        public void Update(Guid id, Request model)
        {
            var request = _requests.Where(x => x.RequestId == id).FirstOrDefault();
            if(request != null)
            {
                request.Title = model.Title == "" ? request.Title : model.Title;
                request.Priority = model.Priority;
                request.Description = model.Description == "" ? request.Description : model.Description;
                request.Comments = model.Comments == "" ? request.Comments : model.Comments;
                _jsonDataFile.Save();
            }
        }
        
    }

    public class Requests : List<Request>
    {
        public Requests()
        {
            
        }
    }
}
