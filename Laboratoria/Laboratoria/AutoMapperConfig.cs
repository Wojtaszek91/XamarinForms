using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Laboratoria.Models;

namespace Laboratoria
{
    class AutoMapperConfig
    {
        public AutoMapperConfig()
        {
            
        }
        public IMapper mapper = CreateMapper();
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Installations, InstallationsEntity>();
                cfg.CreateMap<InstallationsEntity, Installations>();

                cfg.CreateMap<Measurements, MeasurmentsEntity>();
                cfg.CreateMap<MeasurmentsEntity, Measurements>();

                cfg.CreateMap<MeasurementItem, MeasurmentItemEntity>();
                cfg.CreateMap<MeasurmentItemEntity, MeasurementItem>();

            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
