using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webTemplate.Mappers
{
    public interface IMapper
    {
        object Map(object source, Type sourceType, Type destinationType);
    }
}