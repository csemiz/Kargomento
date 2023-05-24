using KargomentoEL.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoBL.InterfacesOfManagers
{

    public interface IManager<T, Id>
    {
        IDataResult<T> Add(T model); // ekleme için IResult değil IDataREsult kullandık. Çünkü eklenen verinin idsine ihtiyaç duyarsak geriye dönen datadan idyi alabiliriz.
        IResult Update(T model);
        IResult Delete(T model);
        IDataResult<ICollection<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        IDataResult<T> GetByConditions(Expression<Func<T, bool>>? filter = null);
        IDataResult<T> GetById(Id id);

    }
}

