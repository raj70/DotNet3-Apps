using Json.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.Domain
{
    public class Client
    {
        public Client()
        {

        }

        public Guid ClientId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            bool equal = false;
            var o = obj as Client;
            if (o != null)
            {
                if (o.ClientId == ClientId
                    && o.Name == Name
                    && o.MiddleName == MiddleName
                    && o.LastName == LastName)
                {
                    equal = true;
                }
            }
            return equal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
