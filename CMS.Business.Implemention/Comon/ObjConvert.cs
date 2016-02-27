using AutoMapper;
using CMS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Implemention
{
    public class ObjConvert
    {
        static ObjConvert()
        {
            Mapper.Initialize(x => x.AddProfile<MappingProfile>());
            //Mapper.AssertConfigurationIsValid();
        }

        public static TReturn Convert<TSource, TReturn>(TSource obj)
        {
            return Mapper.Map<TSource, TReturn>(obj);
        }
    }
}
