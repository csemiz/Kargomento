using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoDL.InterfacesOfRepo
{
        public interface IRepository<T, Id> where T : class, new()
        {
            int Add(T entity);
            int Update(T entity);
            int Delete(T entity);
            T GetById(Id id);
            IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, string[]? includeRelationalTables = null);
            T GetByConditions(Expression<Func<T, bool>>? filter = null, string[]? includeRelationalTables = null);
        }
    }

