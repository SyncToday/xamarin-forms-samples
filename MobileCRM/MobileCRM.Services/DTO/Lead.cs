using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCRM.Services.DTO
{
    public class Lead : Contact,
        IConvertable<MobileCRM.Services.DTO.Lead, MobileCRM.Models.Lead>,
        IConvertable<MobileCRM.Models.Lead, MobileCRM.Services.DTO.Lead>

    {
        public Lead Convert(Models.Lead from)
        {
            return (Lead)base.Convert(from);
        }

        public Models.Lead Convert(Lead from)
        {
            return (Models.Lead)base.Convert(from);
        }

        protected override Models.Contact CreateNewModelsEntity()
        {
            return new Models.Lead();
        }
    }
}
