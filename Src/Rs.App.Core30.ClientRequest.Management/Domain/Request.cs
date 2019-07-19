using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.Domain
{
    public enum RequestPriority { Urgent, High, Medium, Low}
    public class Request
    {
        public Request()
        {

        }
        public Guid RequestId { get; set; } = Guid.NewGuid();
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public RequestPriority Priority { get; set; } = RequestPriority.Low;

    }
}
