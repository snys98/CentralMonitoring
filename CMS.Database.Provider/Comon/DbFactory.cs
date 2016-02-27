using Autofac;
using Autofac.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Database.Provider
{
    /// <summary>
    /// 数据库创建工厂简易实现
    /// </summary>
    internal class DbFactory
    {
        private static IContainer container = null;
        static DbFactory()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader("Database"));
            container = builder.Build();
        }
        /// <summary>
        /// 获取一个数据库实体
        /// </summary>
        /// <returns></returns>
        public static DbContent Create()
        {
            return container.Resolve<DbContent>();
        }
    }
}
