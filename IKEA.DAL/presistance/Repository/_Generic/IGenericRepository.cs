using IKEA.DAL.Models;
using IKEA.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.presistance.Repository._Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        IEnumerable<T> GetAll(bool withAsTracking = true);
        IQueryable<T> GetAllAsQueryable();//note
        T? GetbyID(int id);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
