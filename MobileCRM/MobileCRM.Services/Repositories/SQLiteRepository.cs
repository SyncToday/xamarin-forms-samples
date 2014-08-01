using MobileCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCRM.Services.Repositories
{
    public abstract class SQLiteRepository<TFrontEnd, TDatabase> : IRepository<TFrontEnd>
        where TFrontEnd : class, IContact, new()
        where TDatabase : class, MobileCRM.Services.DTO.IBusinessEntity, MobileCRM.Services.DTO.IConvertable<TFrontEnd, TDatabase>, MobileCRM.Services.DTO.IConvertable<TDatabase, TFrontEnd>, new()
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


        public async Task<IEnumerable<TFrontEnd>> All()
        {
            return GetAllItems();
        }

        // TODO: remove this horrible implementation and replace it with real calls to SQLite
        protected IList<TFrontEnd> GetAllItems()
        {
            var data = db.GetItems<TDatabase>();
            List<TFrontEnd> result = new List<TFrontEnd>();
            foreach (var row in data)
            {
                result.Add(row.Convert(row));
            }
            return result;
        }

        public async Task<IEnumerable<TFrontEnd>> FindAsync(Func<TFrontEnd, bool> predicate)
        {
            return GetAllItems().Where(predicate);
        }

        public async Task<TFrontEnd> Get(Func<TFrontEnd, bool> predicate)
        {
            return GetAllItems().SingleOrDefault(predicate);
        }

        public async Task<TFrontEnd> Update(TFrontEnd item)
        {
            var dbItem = new TDatabase();
            dbItem = dbItem.Convert(item);
            var changedItems = db.SaveItem<TDatabase>(dbItem);
            int id = dbItem.ID;
            return db.GetItem<TDatabase>(id) as TFrontEnd;
        }

        public async Task Delete(TFrontEnd item)
        {
            var dbItem = new TDatabase();
            dbItem = dbItem.Convert(item);
            int id = dbItem.ID;
            db.DeleteItem<TDatabase>(id);
        }

        public async Task<TFrontEnd> Add(TFrontEnd item)
        {
            return await Update(item);
        }

        public void Dispose()
        {
        }
    }
}
