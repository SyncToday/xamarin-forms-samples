using MobileCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCRM.Services.Repositories
{
    public abstract class SQLiteRepository<T> : IRepository<T> where T : class, MobileCRM.Services.Models.IBusinessEntity, IContact, new()
    {
        MobileCRM.Services.DataLayer.SQLDatabase db = null;
		protected static string dbLocation;
        
        //new MobileCRM.Services.DataLayer.SQLDatabase(dbLocation);
        protected abstract MobileCRM.Services.DataLayer.SQLDatabase GetSQLDatabase(string dbLocation);

        protected SQLiteRepository()
		{
			// set the db location
            dbLocation = GetDatabaseFilePath();
			
			// instantiate the database	
            db = GetSQLDatabase(dbLocation);
		}
		
        protected abstract string GetDatabaseFilePath();


        public async Task<IEnumerable<T>> All()
        {
            return db.GetItems<T>();
        }

        // TODO: remove this horrible implementation and replace it with real calls to SQLite
        protected IList<T> GetAllItems()
        {
            return new List<T>(db.GetItems<T>());
        }

        public async Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
        {
            return GetAllItems().Where(predicate);
        }

        public async Task<T> Get(Func<T, bool> predicate)
        {
            return GetAllItems().SingleOrDefault(predicate);
        }

        public async Task<T> Update(T item)
        {
            var changedItems = db.SaveItem<T>(item);
            int id = item.ID;
            return db.GetItem<T>(id);
        }

        public async Task Delete(T item)
        {
            int id = item.ID;
            db.DeleteItem<T>(id);
        }

        public async Task<T> Add(T item)
        {
            return await Update(item);
        }

        public void Dispose()
        {
        }
    }
}
