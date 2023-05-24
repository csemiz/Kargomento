using KargomentoDL.InterfacesOfRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KargomentoDL.ImplementationsOfRepo
{
    public class Repository<T, Id> : IRepository<T, Id> where T : class, new()
    {
        protected readonly MyContext _context;
        public Repository(MyContext context)
        {
            _context = context; //DI dependencie injection
        }
        public int Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, string[]? includeRelationalTables = null)
        {
            try
            {
                //select * from TabloAdı
                IQueryable<T> query = _context.Set<T>();
                if (filter != null)
                {
                    //Eğer koşul verdiyse select * from tabloAdi where koşul/koşullar.
                    query = query.Where(filter);
                }
                if (includeRelationalTables != null)
                {
                    //ilişkiliTabloAdi1, ilişkiliTabloADi2,....
                    foreach (var item in includeRelationalTables)
                    {
                        query = query.Include(item); //join yapar
                    }
                }
                return query.AsNoTracking();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public T GetByConditions(Expression<Func<T, bool>>? filter = null, string[]? includeRelationalTables = null)
        {
            try
            {
                //select * from TabloAdı
                IQueryable<T> query = _context.Set<T>();
                if (filter != null)
                {
                    //Eğer koşul verdiyse select * from tabloAdi where koşul/koşullar.
                    query = query.Where(filter);
                }
                if (includeRelationalTables != null)
                {
                    //ilişkiliTabloAdi1, ilişkiliTabloADi2,....
                    foreach (var item in includeRelationalTables)
                    {
                        query = query.Include(item); //join yapar
                    }
                }
                return query.AsNoTracking().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public T GetById(Id id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
