﻿using AutoMapper;

namespace E_Commerce.Application.Mapping
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();


            });
            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}
