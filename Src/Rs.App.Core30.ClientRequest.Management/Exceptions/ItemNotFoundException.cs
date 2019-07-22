using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.Exceptions
{

    [Serializable]
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() {            
        }
        public ItemNotFoundException(string message) : base(message) { }
        public ItemNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected ItemNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
