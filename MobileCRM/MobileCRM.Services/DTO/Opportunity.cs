using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCRM.Services.DTO
{
    public class Opportunity : Contact,
        IConvertable<MobileCRM.Services.DTO.Opportunity, MobileCRM.Models.Opportunity>,
        IConvertable<MobileCRM.Models.Opportunity, MobileCRM.Services.DTO.Opportunity>
    {
        public bool IsQualified { get; set; }
        public Decimal EstimatedAmount { get; set; }

        public Opportunity Convert(Models.Opportunity from)
        {
            var result = (Opportunity)base.Convert(from);
            result.IsQualified = from.IsQualified;
            result.EstimatedAmount = from.EstimatedAmount;
            return result;
        }

        public Models.Opportunity Convert(Opportunity from)
        {
            var result = (Models.Opportunity)base.Convert(from);
            result.IsQualified = from.IsQualified;
            result.EstimatedAmount = from.EstimatedAmount;
            return result;
        }

        protected override Models.Contact CreateNewModelsEntity()
        {
            return new Models.Opportunity();
        }
    }
}
