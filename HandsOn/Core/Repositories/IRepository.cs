using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HandsOn.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(Func<TEntity, bool> predicate);

        Task<IEnumerable<TEntity>> GetAll();
    }
}
