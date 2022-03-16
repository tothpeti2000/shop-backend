using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public abstract class BaseRepository
    {
        protected readonly ShopContext db;
        protected readonly IMapper mapper;

        public BaseRepository(ShopContext db)
        {
            this.db = db;

            var config = new MapperConfiguration(config =>
            {
                AddProfiles(config);
            });

            mapper = config.CreateMapper();
        }

        public abstract void AddProfiles(IMapperConfigurationExpression config);
    }
}
