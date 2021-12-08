using System;
using Api.Crosscutting.AutoMapper;
using AutoMapper;

namespace Api.Test.Services
{
    public abstract class BaseServiceTest
    {
        public IMapper Mapper { get; set; }

        public BaseServiceTest()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.AddProfile(new MappingProfile());
                });

                return config.CreateMapper();
            }

            public void Dispose()
            {
            }
        }
    }
}