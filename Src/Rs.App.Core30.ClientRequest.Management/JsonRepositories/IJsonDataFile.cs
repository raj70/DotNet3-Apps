using Rs.App.Core30.ClientRequest.Management.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Management.JsonRepositories
{
    public interface IJsonDataFile<TModel>
    {
        void Initialise();
        void Save();
    }
}
