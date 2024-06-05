using CMS.Model;
using CMS.Repository.AutoMapper;
using CMS.Repository.Common;
using CMS.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Service
{
    public class Service : IService
    {
        private readonly IRepository _repository;
        private readonly IRepositoryMappingService _mappingService;

        public Service(IRepository repository, IRepositoryMappingService mappingService)
        {
            _repository = repository;
            _mappingService = mappingService;
        }

        public IEnumerable<OsobaDomain> PrikaziSveOsobe()
        {
            var osobe = _repository.PrikaziSveOsobe();
            return _mappingService.Map<IEnumerable<OsobaDomain>>(osobe);
        }
    }
}
