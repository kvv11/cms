using CMS.DAL.DataModel;
using CMS.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Repository
{
    public class Repository : IRepository
    {
        private readonly CMSContext _context;

        public Repository(CMSContext context)
        {
            _context = context;
        }

        public IEnumerable<Osobe> PrikaziSveOsobe()
        {
            return _context.Osobe.ToList();
        }
    }
}
