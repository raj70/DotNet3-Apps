using Rs.App.Core30.ClientRequest.Management.Domain;
using Rs.App.Core30.ClientRequest.Management.JsonRepositories;
using Rs.App.Core30.ClientRequest.Management.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Wpf.ViewModel
{
    public class RequestsViewModel : AbstractViewModel
    {
        private List<Request> _requests;
        private IRequestRepository _repository;

        public RequestsViewModel(IRequestRepository repository): base()
        {
            if(_requests== null)
            {
                _requests = new List<Request>();
            }
            _repository = repository;
        }

        public Guid ClientId
        {
            get;
            set;
        }

        public void Initialise()
        {
            _requests = _repository.GetAll(ClientId);
            if (_requests == null)
            {
                _requests = new Requests();
            }
        }

        public List<Request> Requests
        {
            get
            {
                return _requests;
            }
            set
            {
                _requests = value;
                RaisePropertyChangedEvent(nameof(Requests));
            }
        }
              

        public List<RequestPriority> Priorities
        {
            get
            {
                var list = new List<RequestPriority>();
                list.Add(RequestPriority.High);
                list.Add(RequestPriority.Low);
                list.Add(RequestPriority.Medium);
                list.Add(RequestPriority.Urgent);
                list.Add(RequestPriority.Completed);
                return list;
            }            
        }
    }
}
