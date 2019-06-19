using System;
using System.Collections.Generic;
using System.Linq;
using CAN.LMA.WebUI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CAN.LMA.WebUI.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly LibraryManagementDbContext _context;

        public Repository(LibraryManagementDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        protected void Save()
        {
            _context.SaveChanges();
        }
    }
}