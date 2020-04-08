﻿using AhphOcelot.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;
using System;

namespace AhphOcelot
{
    /// <summary>
    /// 扩展Ocelot实现的自定义的注入
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加默认的注入方式，所有需要传入的参数都是用默认值
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IOcelotBuilder AddAhphOcelot(this IOcelotBuilder builder, Action<AhphOcelotConfiguration> option)
        {
            builder.Services.Configure(option);
            //配置信息
            builder.Services.AddSingleton(
                resolver => resolver.GetRequiredService<IOptions<AhphOcelotConfiguration>>().Value);
            //配置文件仓储注入
            builder.Services.AddSingleton<IFileConfigurationRepository, SqlServerFileConfigurationRepository>();
            return builder;
        }
    }
}
