using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Nito.AsyncEx;

namespace ConsoleContactAPI
{
    public interface IFullContactApi
    {
        Task<FullContactPerson> LookupPersonByEmailAsync(string email);
    }

}
