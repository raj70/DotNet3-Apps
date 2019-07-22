using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.Domain
{
    public enum RequestPriority { Urgent, High, Medium, Low, Completed}
    public class Request
    {
        public Request()
        {

        }
        public Guid RequestId { get; set; } = Guid.NewGuid();
        [Required]
        public Guid ClientId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public RequestPriority Priority { get; set; } = RequestPriority.Low;

        public bool IsValidate()
        {
            bool isValid = true;

            if (Guid.Empty == ClientId)
            {
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(Title))
            {
                isValid = false;
            }

            if (!isValid && string.IsNullOrWhiteSpace(Description))
            {
                isValid = false;
            }

            return isValid;
        }
        public override bool Equals(object obj)
        {
            bool isEqual = false;

            var r = obj as Request;
            if (r != null)
            {
                if (r.RequestId == RequestId)
                {
                    isEqual = true;
                }
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
