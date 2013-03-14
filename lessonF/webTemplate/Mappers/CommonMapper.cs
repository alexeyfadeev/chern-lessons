using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using webTemplate.Model;
using webTemplate.Models.ViewModels;


namespace webTemplate.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            MapperCollection.LoginUserMapper.Init();
            MapperCollection.UserMapper.Init();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}