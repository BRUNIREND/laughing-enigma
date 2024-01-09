using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Mod;

namespace DataAccessLayer
{
    /// <summary>
    /// Определяем базовые операции в интерфейсе
    /// </summary>
    /// <typeparam name="T"> Любой элемент</typeparam>
    public interface IRepository<T> : IDisposable where T: class
    {
        IEnumerable<T> GetBookList();
       
        void Create(T item);
        void Update(T item);
        void Delete(Student item);
        void Save();

    }   

    
    
    
   
}










