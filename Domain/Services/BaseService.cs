using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public abstract class BaseService
    {
        protected readonly IMapper mapper;

        public BaseService()
        {
            var config = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}
