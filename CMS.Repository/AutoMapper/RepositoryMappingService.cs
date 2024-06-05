using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using CMS.DAL.DataModel;
using CMS.Model;

namespace CMS.Repository.AutoMapper
{
    public class RepositoryMappingService : IRepositoryMappingService
    {
        private readonly IMapper _mapper;

        public RepositoryMappingService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Osobe, OsobaDomain>().ReverseMap();
                cfg.CreateMap<Citatelji, CitateljDomain>().ReverseMap();
                cfg.CreateMap<Novinari, NovinarDomain>().ReverseMap();
                cfg.CreateMap<Clanci, ClanakDomain>().ReverseMap();
                cfg.CreateMap<Komentari, KomentarDomain>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
