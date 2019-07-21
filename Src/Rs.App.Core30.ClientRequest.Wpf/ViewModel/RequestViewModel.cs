using Rs.App.Core30.ClientRequest.Management.Domain;
using Rs.App.Core30.ClientRequest.Management.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Wpf.ViewModel
{
    public class RequestViewModel: AbstractViewModel
    {
        private Request _request;
        private IRepository<Request> _repository;

        public RequestViewModel(IRepository<Request> repository): base()
        {
            if(_request== null)
            {
                _request = new Request();
            }
            _repository = repository;
        }

        public void Initialise()
        {
            var id = ClientId;
            _request = _repository.Get(ClientId);
            if (_request == null)
            {
                _request = new Request();
                if (_request.ClientId == Guid.Empty)
                {
                    _request.ClientId = id;
                }
            }
        }

        public Guid ClientId
        {
            get
            {
                return _request.ClientId;
            }
            set
            {
                _request.ClientId = value;
            }
        }
        public string Title
        {
            get
            {
                return _request.Title;
            }
            set
            {
                _request.Title = value;
                RaisePropertyChangedEvent(nameof(Title));
            }
        }
        public string Description
        {
            get
            {
                return _request.Description;
            }
            set
            {
                _request.Description = value;
                RaisePropertyChangedEvent(nameof(Description));
            }
        }
        public string Comments
        {
            get
            {
                return _request.Comments;
            }
            set
            {
                _request.Comments = value;
                RaisePropertyChangedEvent(nameof(Comments));
            }
        }

        public RequestPriority Priority
        {
            get
            {
                return _request.Priority;
            }
            set
            {
                _request.Priority = value;
                RaisePropertyChangedEvent(nameof(Priority));
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

        public void Add()
        {
            _repository.Add(_request);
        }
    }
}
