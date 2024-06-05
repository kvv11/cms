using CMS.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Repository.Common
{
    public interface IRepository
    {
        IEnumerable<Osobe> PrikaziSveOsobe();
    }
}
