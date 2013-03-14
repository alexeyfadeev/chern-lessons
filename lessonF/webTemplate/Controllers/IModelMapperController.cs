using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webTemplate.Mappers;

namespace webTemplate.Controllers
{
    public interface IModelMapperController
    {
        IMapper ModelMapper { get; }
    }
}
