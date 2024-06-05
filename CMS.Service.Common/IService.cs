using CMS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Service.Common
{
    public interface IService
    {
        IEnumerable<OsobaDomain> PrikaziSveOsobe();
    }
}

