using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;    
using System.Linq;
using Dapper;
using Mod;
namespace DataAccessLayer
{
   public class DapperStudentsRepository<T> : IRepository<T> where T : Student, IDomainObject, new()
    {
        private static string _connectionString =
            "data source=(localdb)\\MSSQLLocalDB;Initial Catalog=DbConnect; Integrated Security=True;";

        private IDbConnection _db;
        public DapperStudentsRepository() => _db = new SqlConnection(_connectionString);
        /// <summary>
        /// Получаем записи через Dapper
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetBookList() => _db.Query<T>("SELECT * FROM Students").ToList();
        
        public T GetItem(int id) => _db.Query<T>("Select * from Students where Id = @id", new { id }).FirstOrDefault();
        
        /// <summary>
        /// Создаем новую запись через Dapper и SQL запрос
        /// </summary>
        /// <param name="item">Объект для записи</param>
        public void Create(T item)
        {
            var sqlQuery = "INSERT INTO Students (Name, Speciality, [Group])" +
                           "VALUES (@Name, @Speciality, @Group);" +
                           "SELECT CAST(SCOPE_IDENTITY() as int)";
            int itemId = _db.Query<int>(sqlQuery, item).FirstOrDefault();
            item.ID = itemId;
        }

        /// <summary>
        /// Обновление записи
        /// </summary>
        /// <param name="item">Объект для обновления</param>
        public void Update(T item)
        {
            var sqlQuery = "UPDATE Students SET Name = @Name, Speciality = @Speciality, [GROUP] = @Group WHERE Id = @Id";

            _db.Execute(sqlQuery, item);
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="st">Объект для удаления</param>
        public void Delete(Student st)
        {
            int value = 0;
            var persons = GetBookList();
            foreach (var person in persons) 
            {
                if (st.Name == person.Name && st.Speciality == person.Speciality && st.Group == person.Group)
                {
                    value = person.ID;
                    
                    break;
                }
            }
            var sqlQuery = "DELETE FROM Students WHERE Id = @value";
            _db.Execute(sqlQuery, new { value });

        }

        public void Save()
        {
        }

        public bool _dispose = false;

        /// <summary>
        /// Реализуем сборщик мусора
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!_dispose)
            {
                if (disposing)
                {
                    _db.Dispose();
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