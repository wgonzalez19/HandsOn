using HandsOn.Core.Repositories;
using HandsOn.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HandsOn.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Repository()
        {

        }

        public async Task<TEntity> Get(Func<TEntity, bool> predicate)
        {
            try
            {
                IEnumerable<TEntity> entities = await DataService<TEntity>.GetData("api/Employees");

                var result = entities.Where(predicate).SingleOrDefault();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                IEnumerable<TEntity> result = await DataService<TEntity>.GetData("api/Employees");

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
