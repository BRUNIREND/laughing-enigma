using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Mod;
namespace DataAccessLayer
{
    /// <summary>
    /// Контсекст для работы с бд через Entity
    /// </summary>
    public class Context: DbContext
    {
        public Context() : base("DBConnect")
        {
        }

        public DbSet<Student> Students { get; set; }
    }
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class, IDomainObject, new()
    {
        private Context _context;
        public EntityFrameworkRepository() => _context = new Context();
        

        
        /// <summary>
        /// Получаем список объектов из бд
        /// </summary>
        /// <returns>Список объектов</returns>
        public IEnumerable<T> GetBookList()
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// Метод создания новой записи в бд
        /// </summary>
        /// <param name="obj">Объект для записи (Student)</param>
        public void Create(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновление записи в бд (Пока не реализовано)
        /// </summary>
        /// <param name="obj">Объект для обновления (Student)</param>
        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }


        /// <summary>
        /// Удаление студента из бд, используем самого студента вместо ID
        /// </summary>
        /// <param name="item"></param>
        /// <param name="st">Объект для удаления из бд</param>
        public void Delete(Student item)
        {
            int value = 0;
            Student st = item;
            foreach (var person in _context.Students) 
            {
                if (st.Name == person.Name && st.Speciality == person.Speciality && st.Group == person.Group)
                {
                    value = person.ID;
                    
                    break;
                }
            }
            try
            {
                T buffert = _context.Set<T>().Find(value);
                _context.Students.Remove(_context.Students.Find(value));
                _context.SaveChanges();
            }
            catch (Exception e)
            {
            }
            
        }

        /// <summary>
        /// Сохранение записи в бд (Можно обойтись и без него)
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        public bool _dispose = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_dispose)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }

}