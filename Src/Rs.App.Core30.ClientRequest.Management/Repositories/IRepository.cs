using Rs.App.Core30.ClientRequest.Management.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.Repositories
{
    public interface IRepository<TModel>
    {
        TModel Get(Guid id);
        List<TModel> GetAll();
        void Add(TModel model);
        void Update(Guid id, TModel model);
        void Delete(Guid id);
    }

    public interface IRequestRepository : IRepository<Request>
    {
        List<Request> GetAll(Guid clientId);
    }
}
