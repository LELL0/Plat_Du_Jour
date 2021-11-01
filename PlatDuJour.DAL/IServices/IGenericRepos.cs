using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL.IServices
{
    public interface IGenericRepos<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetById(int Id);

        Task<T> GetById(string id);

        Task<T> Create(T entity);

        Task Update(T entity);

        Task Delete(int id);
    }
}
