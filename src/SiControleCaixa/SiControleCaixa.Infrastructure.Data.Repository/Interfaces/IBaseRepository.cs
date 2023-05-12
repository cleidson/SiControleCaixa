using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.Infrastructure.Data.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> ListAll();
        Task<List<T>> ListAllAsync();
        bool Add(T entity);
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        void Delete(T entity);
    }
}
