using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Nito.AsyncEx;

namespace FullContactAPILib
{
    public interface IFullContactApi
    {
        Task<FullContactPerson> LookupPersonByEmailAsync(string email);
    }

}
