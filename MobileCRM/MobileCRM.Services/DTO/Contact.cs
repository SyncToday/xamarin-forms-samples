using MobileCRM.Services.DataLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCRM.Services.DTO
{
    public class Contact : IBusinessEntity, 
        IConvertable<MobileCRM.Services.DTO.Contact, MobileCRM.Models.Contact>,
        IConvertable<MobileCRM.Models.Contact, MobileCRM.Services.DTO.Contact>
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        string FirstName { get; set; }
        string LastName { get; set; }

        string Company { get; set; }
        string Title { get; set; }
        string Industry { get; set; }

        string Email { get; set; }
        string Website { get; set; }

        string Phone { get; set; }
        string Mobile { get; set; }
        string Fax { get; set; }

        string Address { get; set; }
        string BillingAddress { get; set; }
        string ShippingAddress { get; set; }

        string Twitter { get; set; }
        string LinkedIn { get; set; }
        string Facebook { get; set; }
        string Skype { get; set; }

        string Owner { get; set; }

        public Contact Convert(Models.Contact from)
        {
            ID = from.ID;
            this.FirstName = from.FirstName;
            this.LastName = from.LastName;
            this.Company = from.Company;
            this.Title = from.Title;
            this.Industry = from.Industry;
            this.Email = from.Email;
            this.Website = from.Website;
            this.Phone = from.Phone;
            this.Mobile = from.Mobile;
            this.Fax = from.Fax;
            this.Address = JsonConvert.SerializeObject(from.Address);
            return this;
        }

        protected virtual Models.Contact CreateNewModelsEntity()
        {
            return new Models.Contact(); 
        }

        public Models.Contact Convert(Contact from)
        {
            Models.Contact result = CreateNewModelsEntity();
            result.ID = from.ID;
            result.FirstName = from.FirstName;
            result.LastName = from.LastName;
            result.Company = from.Company;
            result.Title = from.Title;
            result.Industry = from.Industry;
            result.Email = from.Email;
            result.Website = from.Website;
            result.Phone = from.Phone;
            result.Mobile = from.Mobile;
            result.Fax = from.Fax;
            result.Address = JsonConvert.DeserializeObject<MobileCRM.Models.Address>(from.Address);

            return result;
        }
    }
}
