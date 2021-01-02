using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.DataAbstraction
{
    public interface IRepository<T, TKey> where T : class, IEntity<TKey>
    {
        //This interfce contains declaration of CRUD methods without their implementation, and it has a Generic type
        //so that it can be re-used by other classes that implement this interface

        T GetById(TKey Id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        List<T> GetAll();
        List<T> GetAllFiltered(Expression<Func<T, bool>> prediacte);


        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
