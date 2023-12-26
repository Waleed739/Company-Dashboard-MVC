using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:BaseEntity
    {
        private readonly MVCDbContext _context;

        public GenericRepository(MVCDbContext context)
        {
            _context = context;
        }
        public int Add(T entity)
        {
            _context.Set<T>().Add(entity) ;
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public int Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChanges();
        }
    }
}
