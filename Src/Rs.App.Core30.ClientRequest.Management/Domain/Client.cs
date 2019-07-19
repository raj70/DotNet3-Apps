﻿using Json.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.Domain
{
    public class Client
    {
        public Client()
        {

        }

        public Guid ClientId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            bool equal = false;
            var o = obj as Client;
            if(o.ClientId == ClientId 
                && o.Name == Name 
                && o.MiddleName == MiddleName 
                && o.LastName == LastName)
            {
                equal = true;
            }
            return equal;
        }
    }
}