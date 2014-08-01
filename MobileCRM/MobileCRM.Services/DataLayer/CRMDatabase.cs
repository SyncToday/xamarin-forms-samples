using MobileCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCRM.Services.DataLayer
{
    public class CRMDatabase : SQLDatabase
    {
        public CRMDatabase(string path)
            : base(path)
		{
		}

        internal static CRMDatabase _instance;

        public override void CreateTables()
        {
            //CreateTable<Account>();
            CreateTable<Contact>();
            /*CreateTable<Lead>();
            CreateTable<Opportunity>();
            CreateTable<User>();*/
        }
    }
}
