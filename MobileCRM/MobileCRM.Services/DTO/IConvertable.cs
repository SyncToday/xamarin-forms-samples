using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCRM.Services.DTO
{
    public interface IConvertable<T, U>
        where T : class
        where U : class
    {
        T Convert(U from);
    }
}
