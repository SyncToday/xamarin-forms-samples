using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCRM.Services.DTO
{
    public class Account : Contact,
        IConvertable<MobileCRM.Services.DTO.Account, MobileCRM.Models.Account>,
        IConvertable<MobileCRM.Models.Account, MobileCRM.Services.DTO.Account>
    {
        public Account Convert(Models.Account from)
        {
            return (Account)base.Convert(from);
        }

        public Models.Account Convert(Account from)
        {
            return (Models.Account)base.Convert(from);
        }

        protected override Models.Contact CreateNewModelsEntity()
        {
            return new Models.Account();
        }
    }
}
