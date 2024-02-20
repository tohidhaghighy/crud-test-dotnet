using Mc2.CrudTest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity<Guid>;
    }
}
