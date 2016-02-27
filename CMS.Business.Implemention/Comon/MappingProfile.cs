using AutoMapper;
using CMS.Models.DB;
using CMS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Implemention
{
    public class MappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return GetType().Name;
            }
        }

        protected override void Configure()
        {
            this.CreateMap<SystemLog, SystemLogEntity>().ForMember(d => d.Level, opt => opt.MapFrom(s => s.Level));
        }

    }
}
