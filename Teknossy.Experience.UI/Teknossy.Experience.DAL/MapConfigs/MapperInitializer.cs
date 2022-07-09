using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Teknossy.Experience.DAL.MapConfigs.Profiles.System;

namespace Teknossy.Experience.DAL.MapConfigs
{
    public class MapperInitializer
    {
        public static IMapper Initialize()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();

            });

            return mappingConfig.CreateMapper();
        }
    }
}
