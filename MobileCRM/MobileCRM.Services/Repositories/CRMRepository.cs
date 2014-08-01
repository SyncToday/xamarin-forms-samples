using MobileCRM.Models;
using MobileCRM.Services.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCRM.Services.Repositories
{
    public class CRMRepository<T> : SQLiteRepository<T> where T : class, MobileCRM.Services.Models.IBusinessEntity, IContact, new()
    {
        protected override DataLayer.SQLDatabase GetSQLDatabase(string dbLocation)
        {
            if (CRMDatabase._instance == null)
            {
                lock (typeof(CRMDatabase))
                {
                    if (CRMDatabase._instance == null)
                    {
                        CRMDatabase._instance = new CRMDatabase(dbLocation);
                    }
                }
            }
            return CRMDatabase._instance;
        }

        protected override string GetDatabaseFilePath()
        {
				var sqliteFilename = "CRMDB.db3";

#if NETFX_CORE
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else

#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
	            var path = sqliteFilename;
#else

#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
	            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
#endif
				var path = Path.Combine (libraryPath, sqliteFilename);
#endif		

#endif
				return path;	
			}

    }
}
