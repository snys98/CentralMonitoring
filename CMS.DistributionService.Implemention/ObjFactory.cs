using Autofac;
using Autofac.Configuration;
using CMS.Business.Implemention;
using CMS.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Implemention
{
    public class ObjFactory
    {
        private static IContainer container = null;
        static ObjFactory()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader("BusinessLayer"));
            container = builder.Build();
        }

        /// <summary>
        /// 获取一个数据库实体
        /// </summary>
        /// <returns></returns>
        public static T Create<T>()
        {
            return container.Resolve<T>();
        }
    }
}
