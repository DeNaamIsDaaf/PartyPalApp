using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartyPalApp.MVVM.Models;

namespace PartyPalApp.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : TableData, new()
    {
        // Create/Update
        void SaveEntity(T entity);

        // Read One/ Read Many
        T? GetEntity(int id);
        List<T>? GetEntities();

        // Delete 
        void DeleteEntity(T entity); // Delete op object
        void DeleteEntityWithChildren(T entity);
    }
}
