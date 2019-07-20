using Rs.App.Core30.ClientRequest.Management.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Wpf.ViewModel
{
    public class ClientViewModel : AbstractViewModel
    {
        private Client _client;
        public ClientViewModel(Client client) : base()
        {
            _client = client;
        }

        public Client Client
        {
            get
            {
                return _client;
            }
        }

        public string Name
        {
            get
            {
                return _client.Name;
            }
            set
            {
                _client.Name = value;
                this.RaisePropertyChangedEvent(nameof(Name));
            }
        }
        public string MiddleName
        {
            get
            {
                return _client.MiddleName;
            }
            set
            {
                _client.MiddleName = value;
                this.RaisePropertyChangedEvent(nameof(MiddleName));
            }
        }
        public string LastName
        {
            get
            {
                return _client.LastName;
            }
            set
            {
                _client.LastName = value;
                this.RaisePropertyChangedEvent(nameof(LastName));
            }
        }

        /// <summary>
        /// Is Not Empty
        /// </summary>
        /// <returns></returns>
        public bool IsValidate()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(Name))
            {
                isValid = false;
            }

            if(!isValid && string.IsNullOrWhiteSpace(MiddleName))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
